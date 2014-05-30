using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ModelTemplate.Models
{
    /// <summary>
    /// Used to do model validation demo
    /// </summary>
    public class Appointment
    {
        //Model验证方法3: 使用元数据指定验证规则
        [Required]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage="Please enter a date")]
        public DateTime Date { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage="You must accept the terms")]
        public bool TermsAccepted { get; set; }

        //[System.Web.Mvc.Compare("The other property")] //和另外一个字段比较
        //[Range(10,20)] //数值类型，限定范围
        //[RegularExpression("")] //给定的字符串必须满足指定的正则表达式
        //[Required] //必选字段
        //[HiddenInput] //隐藏字段
        //[StringLength(100)] //限定输入的字符串长度
        ////所有验证属性都允许输入ErrorMessage
        //public string TestField { get; set; }
    }
}