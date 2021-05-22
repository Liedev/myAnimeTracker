using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace MyAnime_DAL.BaseModels
{
    public abstract class BaseClass : IDataErrorInfo, INotifyPropertyChanged
    {
        // Code below is from course: Excercise Strips
        [NotMapped]
        public virtual string this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();

                var property = GetType().GetProperty(columnName);
                if (property != null)
                {
                    var validationContext = new ValidationContext(this)
                    {
                        MemberName = columnName
                    };

                    var isValid = Validator.TryValidateProperty(property.GetValue(this), validationContext, validationResults);
                    if (isValid)
                    {
                        return null;
                    }

                    return validationResults.First().ErrorMessage;
                }
                return "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsValid()
        {
            return string.IsNullOrWhiteSpace(Error);

        }
        [NotMapped]
        public string Error
        {
            get
            {
                string errors = "";

                foreach (var item in this.GetType().GetProperties(BindingFlags.Instance|BindingFlags.DeclaredOnly|BindingFlags.Public).Where(x => x.CanWrite == true)) //reflection 
                {

                    string error = this[item.Name];
                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        errors += error + Environment.NewLine;
                    }

                }
                return errors;
            }
        }
    }
}
