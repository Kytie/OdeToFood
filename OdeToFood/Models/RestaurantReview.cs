using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models
{
    /*public class MaxWordsAttribute : ValidationAttribute
    {
        public MaxWordsAttribute(int maxWords) : base("{0} has too many words!")
        {
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueAsString = value?.ToString();
            if (!(valueAsString?.Split(' ').Length > _maxWords)) { return ValidationResult.Success; }
            var errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return new ValidationResult(errorMessage);
        }

        private readonly int _maxWords;
    }*/

    public class RestaurantReview //: IValidatableObject
    {
        public int Id { get; set; }
        [Range(1,10)]
        [Required] //redundant as int is a value type and these are already required and cannot be null
        public int Rating { get; set; }
        [Required]
        [StringLength(1024)]
        public string Body { get; set; }
        [Display(Name="User Name")]
        [DisplayFormat(NullDisplayText="anonymous")]
        //[MaxWords(1)]
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }

        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 2 && ReviewerName.ToLower().StartsWith("scott"))
            {
                yield return new ValidationResult("Sorry, SCott, you can't do this");
            }
        }*/
    }
}