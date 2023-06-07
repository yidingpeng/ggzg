using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Common
{
    /// <summary>
    /// 根据Twitter的Snowflake算法生成分布式唯一ID
    /// Snowflake算法 64 位
    /// 0---0000000000 0000000000 0000000000 0000000000 0 --- 00000 ---00000 ---000000000000
    /// 第一位为未使用（实际上也可作为long的符号位），接下来的41位为毫秒级时间，然后5位datacenter标识位，5位机器ID（并不算标识符，实际是为线程标识），
    /// 然后12位该毫秒内的当前毫秒内的计数，加起来刚好64位，为一个Long型。
    /// 其中datacenter标识位起始是机器位，机器ID其实是线程标识，可以同一一个10位来表示不同机器
    /// Add By Leon 李明达 20190907
    /// </summary>
    public class IDWorker
    {
        /// <summary>
        /// 机器ID
        /// </summary>
        private static long workerId;

        /// <summary>
        /// 唯一时间，这是一个避免重复的随机量，自行设定不要大于当前时间戳
        /// </summary>
        private static long twepoch = 687888001020L;

        private static long sequence = 0L;

        /// <summary>
        /// 机器码字节数。4个字节用来保存机器码
        /// </summary>
        private static int workerIdBits = 4;

        /// <summary>
        /// 最大机器ID(其实就是一个最大5位数的最大线程ID)
        /// </summary>
        public static long maxWorkerId = -1L ^ -1L << workerIdBits;

        /// <summary>
        /// 计数器字节数，10个字节用来保存计数码
        /// </summary>
        private static int sequenceBits = 10;

        /// <summary>
        /// 机器码数据左移位数，就是后面计数器占用的位数
        /// </summary>
        private static int workerIdShift = sequenceBits;

        /// <summary>
        /// 时间戳左移动位数就是机器码和计数器总字节数
        /// </summary>
        private static int timestampLeftShift = sequenceBits + workerIdBits;

        /// <summary>
        /// 一微秒内可以产生计数，如果达到该值则等到下一微妙在进行生成
        /// </summary>
        public static long sequenceMask = -1L ^ -1L << sequenceBits;

        private long lastTimestamp = -1L;

        public IDWorker(long workerId)
        {
            if (workerId > maxWorkerId || workerId < 0)
                throw new Exception(string.Format("WorkerID不能大于{0}且不能小于0", maxWorkerId));
            IDWorker.workerId = workerId;
        }

        public long NextID()
        {
            lock (this)
            {
                long timestamp = TimeGen();//当前时间戳

                if (this.lastTimestamp == timestamp)//同一微妙中生成ID
                {
                    //用&运算计算该微秒内产生的计数是否已经到达上限
                    IDWorker.sequence = (IDWorker.sequence + 1) & IDWorker.sequenceMask;
                    if (IDWorker.sequence == 0)
                        timestamp = TillNextMillis(this.lastTimestamp);//一微妙内产生的ID计数已达上限，等待下一微妙
                }
                else//不同微秒生成ID
                    IDWorker.sequence = 0; //计数清0

                if (timestamp < lastTimestamp)
                    //如果当前时间戳比上一次生成ID时时间戳还小，抛出异常，因为不能保证现在生成的ID之前没有生成过
                    throw new Exception(string.Format("时间戳异常，{0}毫秒内拒绝生成ID！", this.lastTimestamp - timestamp));
                this.lastTimestamp = timestamp; //把当前时间戳保存为最后生成ID的时间戳
                long nextId = (timestamp - twepoch << timestampLeftShift) | IDWorker.workerId << IDWorker.workerIdShift | IDWorker.sequence;
                return nextId;
            }
        }

        /// <summary>
        /// 获取下一微秒时间戳
        /// </summary>
        /// <param name="lastTimestamp"></param>
        /// <returns></returns>
        private long TillNextMillis(long lastTimestamp)
        {
            long timestamp = TimeGen();
            while (timestamp <= lastTimestamp)
            {
                timestamp = TimeGen();
            }
            return timestamp;
        }

        /// <summary>
        /// 生成当前时间戳
        /// </summary>
        /// <returns></returns>
        private long TimeGen()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }
    }
}
