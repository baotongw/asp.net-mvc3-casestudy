using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelTemplate.Models;

namespace ModelTemplate.Infrastructure
{
    public class CustomValidationProvider : ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata,
        ControllerContext context)
        {
            //property level
            if (metadata.ContainerType == typeof(Appointment))
            {
                return new ModelValidator[] {
                    new AppointmentPropertyValidator(metadata, context)
                };
            }
            ////model level
            //else if (metadata.ModelType == typeof(Appointment))
            //{
            //    return new ModelValidator[] {
            //        new AppointmentValidator(metadata, context)
            //    };
            //}
            return Enumerable.Empty<ModelValidator>();
        }
    }

    //A property-level model validator
    public class AppointmentPropertyValidator : ModelValidator
    {
        public AppointmentPropertyValidator(ModelMetadata metadata, ControllerContext context)
            : base(metadata, context)
        { }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            Appointment appt = container as Appointment;

            if (appt != null)
            {
                switch (Metadata.PropertyName)
                {
                    case "ClientName":
                        if (string.IsNullOrEmpty(appt.ClientName))
                        {
                            return new ModelValidationResult[] { 
                                new ModelValidationResult{
                                    MemberName="ClientName",
                                    Message="Please enter your name"
                                }
                            };
                        }
                        break;
                    case "Date":
                        if (appt.Date == null || DateTime.Now > appt.Date)
                        {
                            return new ModelValidationResult[] {
                                new ModelValidationResult {
                                    MemberName = "Date",
                                    Message = "Please enter a date in the future"
                                }
                            };
                        }
                        break;
                    case "TermsAccepted":
                        if (!appt.TermsAccepted)
                        {
                            return new ModelValidationResult[] {
                                new ModelValidationResult {
                                    MemberName = "TermsAccepted",
                                    Message = "You must accept the terms"
                                }
                            };
                        }
                        break;
                }
            }

            return Enumerable.Empty<ModelValidationResult>();
        }
    }

    ////a model-level validator
    //public class AppointmentValidator : ModelValidator
    //{
    //    public AppointmentValidator(ModelMetadata metadata, ControllerContext context)
    //        : base(metadata, context)
    //    { }

    //    public override void Validate(Appointment container, IList<ModelValidationResult> errors)
    //    {
    //        Appointment appt = (Appointment)Metadata.Model;
    //        if (appt.ClientName == "Joe" && appt.Date.DayOfWeek == DayOfWeek.Monday)
    //        {
    //            errors.Add(new ModelValidationResult
    //            {
    //                MemberName = "",
    //                Message = "Joe cannot book appointments on Mondays"
    //            });
    //        }
    //    }
    //}
}
