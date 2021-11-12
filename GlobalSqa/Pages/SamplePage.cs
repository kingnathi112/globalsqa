using System;
using System.Linq;
using System.Threading;
using GlobalSqa.Framework.Selenium;
using GlobalSqa.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace GlobalSqa.Pages
{
    public class SamplePage
    {
        public readonly SamplePageButtons Buttons;
        public readonly SamplePageInputs Inputs;
        public readonly SamplePageAds Ads;
        public readonly SamplePageSelects Selects;
        public readonly SamplePageLabels Labels;

        public SamplePage()
        {
            Buttons = new SamplePageButtons();
            Inputs = new SamplePageInputs();
            Ads = new SamplePageAds();
            Selects = new SamplePageSelects();
            Labels = new SamplePageLabels();
        }

        #region Enter Text Methods

        public void EnterName(string name)
        {
            if(Inputs.NameInput != null)
                Inputs.NameInput.SendKeys(name);
        }

        public void EnterEmail(string email)
        {
            if (Inputs.EmailInput != null)
                Inputs.EmailInput.SendKeys(email);
        }
        public void EnterWebsite(string website)
        {
            if (Inputs.WebsiteInput != null)
                Inputs.WebsiteInput.SendKeys(website);
        }
        public void EnterComment(string comment)
        {
            if (Inputs.CommentInput != null)
                Inputs.CommentInput.SendKeys(comment);
        }
        #endregion

        #region Select Methods

        public bool SelectExperience(string experience)
        {
            if (Selects.ExperienceSelect != null)
            {
                Selects.ExperienceSelect.Click();
                SelectElement select = new SelectElement(Selects.ExperienceSelect);
                try
                {
                    select.SelectByText(experience, false);
                    Selects.ExperienceSelect.Click();
                    return true;
                }
                catch (NoSuchElementException e)
                {
                    return false;
                }
            }
            else return false;
        }

        public void SelectExpertise(string name)
        {
            if (Selects.ExpertiseCheck != null)
            {
                var expertise = Selects.ExpertiseCheck.FirstOrDefault(x => x.Text.Trim() == name);
                expertise.Click();
            }
        }

        public void SelectEducation(string name)
        {
            if (Selects.EducationRadio != null)
            {
                var education = Selects.EducationRadio.FirstOrDefault(x => x.Text.Trim() == name);
                education.Click();
            }
        }

        #endregion

        #region Ads

        public void CloseAdByRefreshIntoThePage()
        {
            if (Ads.PopUpAd != null)
                Driver.Refresh();
        }

        #endregion

        #region Click Methods

        public void ClickAlertButton()
        {
            if(Buttons.AlertBoxBtn != null)
                Buttons.AlertBoxBtn.Click();
        }

        public void ClickSubmitButton()
        {
            if (Buttons.SubmitBtn != null)
            {
                ((IJavaScriptExecutor)Driver.Current).ExecuteScript($"return arguments[{Buttons.SubmitBtn}].scrollIntoView(true);");
                Buttons.SubmitBtn.Click();
            }
        }

        #endregion

        #region Alert

        public void CloseQuestionAlertByAccept()
        {
            Driver.Current.SwitchTo().Alert().Accept();
        }

        public void CloseWarningAlertByAccept()
        {
            Driver.Current.SwitchTo().Alert().Accept();
        }

        public void CloseQuestionAlertByCancel()
        {
            Driver.Current.SwitchTo().Alert().Dismiss();
        }
        #endregion

        public bool WaitForPageToLoad()
        {
            if (Labels.PageHeader != null && Inputs.NameInput != null && Inputs.EmailInput != null)
                return true;
            else return false;

        }
    }
    public class SamplePageButtons
    {
        public Element AlertBoxBtn => Driver.FindElement(By.XPath(SamplePageHooks.AlertBoxBtnXPath), "Alert Box Button");
        public Element SubmitBtn => Driver.FindElement(By.CssSelector(SamplePageHooks.SubmitBtnCss), "Submit Button");
    }
    public class SamplePageAds
    {
        public Element PopUpAdCloseBtn => Driver.FindElement(By.Id(SamplePageHooks.GoogleAdsId), "Google Ad Close Button");
        public Element PopUpAd => Driver.FindElement(By.Id(SamplePageHooks.GoogleAd), "Google Ad");
    }

    public class SamplePageSelects
    {
        public Element ExperienceSelect => Driver.FindElement(By.Id(SamplePageHooks.ExperienceId), "Experience");
        public Elements ExpertiseCheck => Driver.FindElements(By.ClassName(SamplePageHooks.ExpertiseClass));
        public Elements EducationRadio => Driver.FindElements(By.ClassName(SamplePageHooks.EducationClass));
    }
    public class SamplePageLabels
    {
        public Element PageHeader => Driver.FindElement(By.ClassName(SamplePageHooks.PageHeaderClass), "Sample Page Test");
    }

    public class SamplePageInputs
    {
        public Element NameInput => Driver.FindElement(By.Id(SamplePageHooks.NameId), "Name");
        public Element EmailInput => Driver.FindElement(By.Id(SamplePageHooks.EmailId), "Email");
        public Element WebsiteInput => Driver.FindElement(By.Id(SamplePageHooks.WebsiteId), "Website");
        public Element CommentInput => Driver.FindElement(By.Id(SamplePageHooks.CommentId), "Comment");
    }
}
