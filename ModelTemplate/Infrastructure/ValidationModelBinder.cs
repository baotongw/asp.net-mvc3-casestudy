using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using ModelTemplate.Models;
using System.Web.Mvc;

namespace ModelTemplate.Infrastructure
{
    public class ValidationModelBinder : DefaultModelBinder
    {
        //Model验证方法2： Performing Validation in the Model Binder
        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, 
            PropertyDescriptor propertyDescriptor, object value)
        {
            //首先调用父类的SetProperty
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);

            //实现属性级别的验证
            switch (propertyDescriptor.Name)
            {
                case "ClientName":
                    if (string.IsNullOrEmpty((string)value))
                    {
                        bindingContext.ModelState.AddModelError("ClientName", "Please enter your name");
                    }
                    break;
                case "Date":
                    if (bindingContext.ModelState.IsValidField("Date") && DateTime.Now > ((DateTime)value))
                    {
                        bindingContext.ModelState.AddModelError("Date", "Please enter a date in the future");
                    }
                    break;
                case "TermsAccepted":
                    if (!((bool)value))
                    {
                        bindingContext.ModelState.AddModelError("TermsAccepted", "You must accpet the terms");
                    }
                    break;
            }
        }

        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            base.OnModelUpdated(controllerContext, bindingContext);

            Appointment model = bindingContext.Model as Appointment;

            if (model != null && bindingContext.ModelState.IsValidField("ClientName") &&
                bindingContext.ModelState.IsValidField("Date") &&
                model.ClientName == "Baotong" && model.Date.DayOfWeek == DayOfWeek.Monday)
            {
                //注册model级别的错误信息
                bindingContext.ModelState.AddModelError("", "Baotong can't book appointment on Mondays");
            }
        }
    }
}