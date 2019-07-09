namespace NeedForCars.Web.Common
{
    public class GlobalConstants
    {
        // File path templates
        public const string MAKE_PATH_TEMPLATE = @"wwwroot\images\makes\{0}.png";



        // Regular Expressions
        public const string EMAIL_REGEX = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                               + "@"
                               + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

        public const string USERNAME_REGEX = "[A-Za-z0-9._]{3,20}";

        public const string CAR_NAME_REGEX = "[A-Za-z 0-9]+";

        public const string GENERATON_NAME_REGEX = @"\d{3}\/\d{2} R\d{2}";

        public const string ENGINE_NAME_REGEX = @"\d.\d( ?[A-Za-z0-9 ]+)?";

        public const string TIRE_SIZE_REGEX = @"\d{3}\/\d{2} R\d{2}";
    }
}
