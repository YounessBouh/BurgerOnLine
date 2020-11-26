

namespace OnlineBurgerApp.Data.Extensions
{
    public static class ModelValidations
    {
        public const int MaxLenght = 30;
        public const int DescriptionMaxLength = 100;
        public const string MaxLengthErrorMsg = "the name should contain maximum 30 characters";
        public const string RequiredFieldErrMsg = "this field is required";
        public const string MaxLengthDescriptionErrMsg = "the Description should contain maximum 100 characters";
        public const string PriceRangeErrMsg = "Price must be between 5.00 and 100.00";
    }
}
