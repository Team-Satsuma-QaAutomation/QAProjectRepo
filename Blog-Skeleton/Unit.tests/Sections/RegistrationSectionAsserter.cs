namespace Unit.tests.Sections
{
    using NUnit.Framework;

    public static class RegistrationSectionAsserter
    {

        public static void AssertMissingEmailMessage(this RegistrationSection page, string text)
        {
            Assert.AreEqual(text, page.ErrorMessagesForMissingEmail);
        }
        public static void AssertMissingFullNamelMessage(this RegistrationSection page, string text)
        {
            Assert.AreEqual(text, page.ErrorMessagesForMissingFullName);
        }
        public static void AssertMissingPasswordMessage(this RegistrationSection page, string text)
        {
            Assert.AreEqual(text, page.ErrorMessagesForMissingPassword);
        }
        public static void AssertMismatchPasswordMessage(this RegistrationSection page, string text)
        {
            Assert.AreEqual(text, page.ErrorMessagesForMismatchPassword);
        }
        public static void AsserInvalidEmailMessage(this RegistrationSection page, string text)
        {
            Assert.AreEqual(text, page.ErrorMessagesForInvalidgEmail);
        }



    }
}

