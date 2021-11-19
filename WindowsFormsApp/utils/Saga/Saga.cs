using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.utils.Saga
{
    class Saga<T>
    {
        //效果队列，如何处理由saga来决定
        public List<Effect<T>> listQue;
        //存放任务
        public List<TaskCompletionSource<T>> listTask;
        //处理数据的通道
        public Channel<T> channel;
        //用于过滤信息的函数
        public Func<Effect<T>, T, bool> IsNeed; 
        //存放Effect执行后需要的结果，供某一阶段使用
        public Dictionary<Effect<T>, T> res;
        //存放处理效果的策略
        Dictionary<EffectType, Action<Effect<T>, TaskCompletionSource<T>>> strategy;


        public Saga()
        {
            res = new Dictionary<Effect<T>, T>();
            listQue = new List<Effect<T>>();
            listTask = new List<TaskCompletionSource<T>>();
            channel = new Channel<T>();
            channel.saga = this;  
            //定义effect处理方法
            strategy = new Dictionary<EffectType, Action<Effect<T>, TaskCompletionSource<T>>>();
            strategy.Add(EffectType.TAKE, runTaskEffect);
            strategy.Add(EffectType.CALL, runCallEffect);
            strategy.Add(EffectType.FORK, runForkEffect);
            strategy.Add(EffectType.PUT, runPutEffect);
            strategy.Add(EffectType.OVERLOAD, runOverloadEffect);
        }

        public Saga(Func<Effect<T>,T,bool> matchFunction):this()
        {
            this.IsNeed += matchFunction;
        }


        public T GetRes(Effect<T> token)
        {
            var _res = this.res[token];
            this.res.Remove(token);
            return _res;
        }   
        /// <summary>
        /// 创建Task效果，用于提取有效数据
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public Effect<T> Take(string pattern)
        {
            return new Effect<T>()
            {
                effectType = EffectType.TAKE,
                param = pattern
            };
        }

        public Effect<T> Call(Action<Func<T,bool>,TaskCompletionSource<T>> action)
        {
            return new Effect<T>()
            {
                effectType = EffectType.CALL,
                param = action
            };
        }

        /// <summary>
        /// 创建Call效果，用于调用函数
        /// </summary>
        /// <param name="generator"></param>
        /// <returns></returns>
        public Effect<T> Call(Func<IEnumerable<Effect<T>>> generator)
        {
            return new Effect<T>()
            {
                effectType = EffectType.OVERLOAD,
                param = generator
             };
        }

        public Effect<T> Put(string action)
        {
            return new Effect<T>()
            {
                effectType = EffectType.PUT,
                param = action
            };
        }
        
        public Effect<T> Fork(Action action)
        {
            return new Effect<T>()
            {
                effectType = EffectType.FORK,
                param = action
            };
        }

        public void Cancel(TaskCompletionSource<T> promise)
        {
            promise.TrySetCanceled();
            for(int i = listTask.Count-1;i>0;i--)
            {
                listTask[i]?.TrySetCanceled();
            }
            Console.WriteLine("Task length :" + listTask.Count);
        }


        /// <summary>
        /// 自动执行saga异步流程
        /// </summary>
        /// <param name="ienum"></param>
        /// <param name="_promise"></param>
        /// <returns></returns>
        public async Task AutoRun(Func<IEnumerable<Effect<T>>> ienum,TaskCompletionSource<T> _promise = null)
        {
            //首先执行ienum函数并获取效果集合
            var enumrator = ienum().GetEnumerator();
            //效果遍历及其处理
            while (enumrator.MoveNext()&&!_promise.Task.IsCompleted)
            {
                var effect = (Effect<T>)enumrator.Current;
                //为单个任务建立异步线程
                var promise = new TaskCompletionSource<T>();
                //将此任务加入任务列表
                listTask.Add(promise);
                //使用该线程执行该效果对应的策略
                strategy[effect.effectType](effect, promise);
                var res = default(T);
                try
                {
                     //等待该任务执行完成
                     res = await promise.Task;
                }
                catch(Exception ex)
                {
                    //任务执行失败
                    //记录日志
                }
                listTask.Remove(promise);
                //任何一个任务被取消，则终止整个主线程
                if(promise.Task.IsCanceled)
                {
                    Console.WriteLine("任务取消");
                    _promise.TrySetCanceled();//将主线程取消
                    break;

                }
                if (effect.effectType == EffectType.TAKE)
                    this.res.Add(effect, res);
                //this.listQue.Add(effect);
            }
            _promise?.TrySetResult(default(T));
        }




        private void runTaskEffect(Effect<T> effect, TaskCompletionSource<T> promise)
        {
            effect.cb = promise.TrySetResult;
            listQue.Add(effect);
        }
        private void runCallEffect(Effect<T> effect,TaskCompletionSource<T> promise)
        {

        }
        private void runForkEffect(Effect<T> effect,TaskCompletionSource<T> promise)
        {

        }

        private void runPutEffect(Effect<T> effect,TaskCompletionSource<T> promise)
        {

        }
        /// <summary>
        /// 处理调用效果
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="promise"></param>
        private void runOverloadEffect(Effect<T> effect,TaskCompletionSource<T> promise)
        {
            var action = (Func<IEnumerable<Effect<T>>>)effect.param;
            Task.Run(() =>
            {
                AutoRun(action, promise);
            });
        }


    }
}
