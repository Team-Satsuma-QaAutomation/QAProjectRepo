using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UI.tests.Pages.RegistrationPage
{
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

        public static void AssertMenageBtnMsgExist(this RegistrationPage regPage)
        {
            Assert.IsTrue(regPage.MenageBtn.Displayed);
            Assert.AreEqual("Hello " + regPage.UniqueEmail + "!", regPage.MenageBtn.Text);
        }
    }
}
