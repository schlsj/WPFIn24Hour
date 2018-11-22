using System;
using System.Globalization;
using System.Windows.Data;

namespace ContactManager.Presenters
{
    public class PhoneConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = value as string;
            if (!string.IsNullOrEmpty(result))
            {
                string filteredResult = FilterNonNumber(result);
                if (filteredResult != string.Empty)
                {
                    long theNumber = System.Convert.ToInt64(filteredResult);
                    switch (filteredResult.Length)
                    {
                        case 11:
                            result = $"{theNumber:+# (###) ###-####}";
                            break;
                        case 10:
                            result = $"{theNumber:(###) ###-####}";
                            break;
                        case 7:
                            result = $"{theNumber:###-####}";
                            break;
                    }
                }
            }
            return result;
        }

        private string FilterNonNumber(string stringToFilter)
        {
            //过滤xx，就是把xx踢出去？
            if (string.IsNullOrEmpty(stringToFilter))
            {
                return string.Empty;
            }
            string result = string.Empty;
            foreach (char c in stringToFilter)
            {
                if (char.IsDigit(c))
                {
                    result += c;
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return FilterNonNumber(value as string);
        }
    }
}
