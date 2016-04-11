using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string t = EnumBookOrderRequestType.BookOrder.ToString();
            //try
            //{
            //    throw new Exception("我的测试");
            //}
            //catch (Exception ex)
            //{
            //    string aa = ex.Data.ToString();
            //}


            //string a = ((int)EnumOrderBookStateV1.IsDeviceNoBlackList).ToString();
            //string b = EnumOrderBookStateV1.IsDeviceNoBlackList.ToString();
            //Console.WriteLine(a);
            //Console.WriteLine(b);

            Queue q = new Queue();

            q.Enqueue('A');
            q.Enqueue('M');
            q.Enqueue('G');
            q.Enqueue('W');

            Console.WriteLine("Current queue: ");
            foreach (char c in q)
                Console.Write(c + " ");
            Console.WriteLine();
            q.Enqueue('V');
            q.Enqueue('H');
            Console.WriteLine("Current queue: ");
            foreach (char c in q)
                Console.Write(c + " ");
            Console.WriteLine();
            Console.WriteLine("Removing some values ");
            char ch = (char)q.Dequeue();
            Console.WriteLine("The removed value: {0}", ch);
            ch = (char)q.Dequeue();
            Console.WriteLine("The removed value: {0}", ch);
            Console.ReadKey();
            Console.ReadLine();
        }
    }
    public enum EnumBookOrderRequestType
    {
        BookOrder,
        BookOrderV1,
        BookOrderV2
    }

    /// <summary>
    /// 下单/占座 错误号
    /// </summary>
    public enum EnumOrderBookStateV1
    {
        [Description("下单成功")]
        HandleOrderSuccess = 3000,

        [Description("会员身份未核实")]
        HandleVerifyErr = 3001,

        [Description("参数错误或缺失")]
        HandleMissingParameterErr = 3002,

        [Description("乘客信息参数错误或缺失")]
        HandleBadMissingParameterErr = 3003,

        [Description("至少有一个乘客是成人")]
        HandleOneAdult = 3004,

        [Description("邮寄信息参数错误或缺失")]
        HandleBadMissingMailErr = 3005,

        [Description("获取缓存结果异常")]
        HandleCacheFailureErr = 3006,

        [Description("下单实时验证票量不足")]
        HandleTicketNotEnoughErr = 3007,

        [Description("公共余票接口未获取到对应的席位")]
        HandlePublicFailErr = 3008,

        [Description("缓存中未获取到该车次的信息")]
        HandleCacheTrainNoErr = 3009,

        [Description("所预定的车次不在可定范围内")]
        HandleTrainNoErr = 3010,

        [Description("缓存中未获取到该座位信息")]
        HandleLostTrainSeatErr = 3011,

        [Description("不符合买儿童票的年龄")]
        HandleChildrenAgeErr = 3012,

        [Description("构建乘客实体异常")]
        HandlePassagerErr = 3013,

        [Description("保险编号未获取到保险")]
        HandleInsuranceErr = 3014,

        [Description("时间信息获取有误")]
        HandleTimeErr = 3015,

        [Description("重复下单")]
        HandleRepeatErr = 3016,

        [Description("验证证件信息验证不通过")]
        HandleCertificateErr = 3017,

        [Description("乘客已办理其他订单")]
        HandleAlreadyListErr = 3018,

        [Description("订单写入失败")]
        HandleInsertOrderDataErr = 3019,

        [Description("不在工作时间")]
        HandleWorkTimeErr = 3020,

        [Description("序列化josn失败")]
        HandleParaJsonErr = 3021,

        [Description("请求公共余票验证不通过")]
        HandleCheckTicketErr = 3022,

        [Description("离发车时间少于两时间")]
        HandleCheckSTrainTimeErr = 3023,

        [Description("请求公共余票验证未获取到数据")]
        HandleCheckTicketNotDataErr = 3024,

        [Description("下单异常")]
        HandleTrainOrderExpErr = 3025,

        [Description("请求placeOrder后插入数据库失败")]
        HandlePlaceOrderENDErr = 3026,

        [Description("乘客姓名超过20个字")]
        HandlePlaceOrderUserNameErr = 3027,

        [Description("抱歉，暂时无法进行下单")]
        HandlePlaceOrderSorry = 3028,

        [Description("有效任务量已超过5个")]
        HandlePlaceOrderPassFive = 3029,

        [Description("超过当天可预约时间")]
        HandlePlaceOrderPassTime = 3030,

        [Description("包含儿童不允许部分提交")]
        HandleChildNotAllowSpear = 3031,

        [Description("更新数据库失败")]
        HandleUpdateDBFail = 3032,

        [Description("申请占座失败")]
        HandleHoldingSeatFail = 3033,

        [Description("核验身份发生异常")]
        HandleValidateCerFail = 3034,

        [Description("删除抢票订单失败")]
        HandleDeleteTicketFail = 3035,

        [Description("未找到该抢票订单")]
        HandleGrabbingNotFund = 3036,

        [Description("未找到该订单")]
        HandleOrderNotFund = 3037,

        [Description("需要绑定12306账号才能下单")]
        HandleOrderBing = 3038,

        [Description("属于设备号黑名单列表")]
        IsDeviceNoBlackList = 3039,

        [Description("占位成功")]
        HandlePlaceOrderSucess = 2000,

        [Description("占位失败(不可重新占座)")]
        HandlePlaceOrderErrV1 = 2001,

        [Description("占位失败(可重新占座)")]
        HandlePlaceOrderErrV2 = 2002,

        [Description("公共重复提交下单请求")]
        HandlePublicRepeatErr = 2003,

        [Description("占座超时")]
        HandlePlaceOrderTimeOutErr = 2004,

        [Description("公共返回的数据缺少车厢号")]
        HandlePublicCarriageNoErr = 2005,

        [Description("公共返回的数据缺少座位号")]
        HandlePublicSeatNoErr = 2006,

        [Description("缺少车厢号或者是座位号")]
        HandleLostSeatErr = 2007,

        [Description("下单成功后请求的坐席和返回坐席不一致")]
        HandlePlaceOrderSeatErr = 2008,

        [Description("下单成功后返回坐席价格不一致，价格存在变动")]
        HandlePlaceOrderPriceErr = 2009,

        [Description("公共返回唯一流水号多次提交数据出现异常请用新的流水号提交")]
        HandlePublicToNoErr = 2010,

        [Description("公共返回第三方接口下单失败")]
        HandlePublicThirdErr = 2011,

        [Description("公共返回预付金额小于票价总额,请修改后重新提交")]
        HandlePublicMoneyErr = 2012,

        [Description("公共返回没有对应的车次信息")]
        HandlePublicTrainNoErr = 2013,

        [Description("公共返回选择的座位席别不可预订")]
        HandlePublicSeatErr = 2014,

        [Description("公共返回出发时间或到达时间与实际不符,请修改后重新提交")]
        HandlePublicStartTimeErr = 2015,

        [Description("占座成功后更新数据库失败")]
        HandlePlaceOrderUpdateError = 2016,

        [Description("添加订单唯一流水号失败")]
        HandleUpdateSerialNumberError = 2017,

        [Description("用户手机号下单不合法")]
        BookOrderWrongful = 2019,

        [Description("异步占座失败")]
        SysBookOrderFail = 2020,

        [Description("请求供应商申请占座接口异常")]
        SysBookOrderFail2 = 2021
    }
}
