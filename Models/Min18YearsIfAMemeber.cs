﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMemeber:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId==MembershipType.Unknown || customer.MembershipTypeId==MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDate==null)
            {
                return new ValidationResult("BirthDate is Required");
            }
            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success
                : new ValidationResult("Customer should be atleast 18 years of age to go on a membership");
        }
    }
}