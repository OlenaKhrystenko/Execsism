public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string code = phoneNumber.Substring(0,3);
        bool _IsNewYork = (code == "212");
        string fake = phoneNumber.Substring(4, 3);
        bool _IsFake = (fake == "555");
        string _LocalNumber = phoneNumber.Substring(phoneNumber.LastIndexOf('-') + 1, 4);

        return (_IsNewYork, _IsFake, _LocalNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
   
}
