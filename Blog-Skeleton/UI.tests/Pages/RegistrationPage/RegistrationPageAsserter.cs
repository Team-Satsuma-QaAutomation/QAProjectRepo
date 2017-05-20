namespace UI.tests.Pages.RegistrationPage
{
    using NUnit.Framework;

    public static class RegistrationPageAsserter
    {
        public static void AssertInvalidEmailMsgExist(this RegistrationPage regPage)
        {
            Assert.IsTrue(regPage.ErrorMsgForEmail.Displayed);
            Assert.AreEqual("The Email field is not a valid e-mail address.", regPage.ErrorMsgForEmail.Text);
        }

        public static void AssertWithoutEmailMsgExist(this RegistrationPage regPage)
        {
            Assert.IsTrue(regPage.ErrorMsgForEmail.Displayed);
            Assert.AreEqual("The Email field is required.", regPage.ErrorMsgForEmail.Text);
        }
        public static void AssertWithoutFullName(this RegistrationPage regPage)
        {
            Assert.IsTrue(regPage.ErrorMsgForFullName.Displayed);
            Assert.AreEqual("The Full Name field is required.", regPage.ErrorMsgForEmail.Text);
        }
        public static void AssertWithoutPasswordMsg(this RegistrationPage regPage)
        {
            Assert.IsTrue(regPage.ErrorMsgForPassword.Displayed);
            Assert.AreEqual("The Password field is required.", regPage.ErrorMsgForEmail.Text);
        }
        public static void AssertMisMatchPasswordMsg(this RegistrationPage regPage)
        {
            Assert.IsTrue(regPage.ErrorMsgForPassword.Displayed);
            Assert.AreEqual("The password and confirmation password do not match.", regPage.ErrorMsgForEmail.Text);
        }

        public static void AssertMenageBtnMsgExist(this RegistrationPage regPage)
        {
            Assert.IsTrue(regPage.MenageBtn.Displayed);
            Assert.AreEqual("Hello " + regPage.UniqueEmail + "!", regPage.MenageBtn.Text);
        }
    }
}
