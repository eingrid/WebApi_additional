using System;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace WEBAPI
{


    class PageAddCandidates{
        IWebDriver driver;

        IWebElement First_name;
        IWebElement Last_name;
        IWebElement Email;
        
        IWebElement KeyWords;
        IWebElement DateOfApplication;
        SelectElement Vacancy;

        IWebElement Save_btn;

        

         public PageAddCandidates(IWebDriver driver){
            this.driver = driver;
            First_name = driver.FindElement(By.XPath("//*[@id='addCandidate_firstName']"));
            Last_name = driver.FindElement(By.XPath("//*[@id='addCandidate_lastName']"));
            Email = driver.FindElement(By.XPath("//*[@id='addCandidate_email']"));
            DateOfApplication = driver.FindElement(By.XPath("//*[@id='addCandidate_appliedDate']"));
            KeyWords = driver.FindElement(By.XPath("//*[@id='addCandidate_keyWords']"));
            Save_btn = driver.FindElement(By.XPath("//*[@id='btnSave']"));
            SelectElement Vacancy = new SelectElement(driver.FindElement(By.XPath("//*[@id='addCandidate_vacancy']")));
        }

         
        
        public void Enter_name(){
            First_name.SendKeys("Nazar");
            Last_name.SendKeys("Andrushko");
        }

        public void Enter_email(){
            Email.SendKeys("SomeEmail@gmail.com");
        }    

        public void Set_DateOfApplication(){
            DateOfApplication.Clear();
            DateOfApplication.SendKeys("2021-12-08");
        }
        public void AddKeywords(){
            KeyWords.SendKeys("SSomeKeyWords");
        }

        public void Save_and_Back(){
            Save_btn.Click();   
            IWebElement Back_btn = driver.FindElement(By.XPath("//*[@id='btnBack']"));
            Back_btn.Click();
        }
        
        public void execute(){
            this.Enter_name();
            this.Enter_email();
            this.Set_DateOfApplication();
            this.AddKeywords();
            this.Save_and_Back();
        }

    }
    class PageCandidates{
        IWebDriver driver;
        By jobTitle = By.XPath("//*[@id='candidateSearch_jobTitle']");
        By vacancypath = By.XPath("//*[@id='candidateSearch_jobVacancy']");
        By hiring_manager = By.XPath("//*[@id='candidateSearch_hiringManager']");

        By PSearch_btn = By.XPath("//*[@id='btnSrch']");

        By Pstatus = By.XPath("//*[@id='candidateSearch_status']");
        By Pcandidate = By.XPath("//*[@id='candidateSearch_candidateName']");
        By PKeyWords = By.XPath("//*[@id='candidateSearch_keywords']");
        By PDateOfApplicationFrom = By.XPath("//*[@id='candidateSearch_fromDate']");
        By PDateOfApplicationTo = By.XPath("//*[@id='candidateSearch_toDate']");
        
        By PMethodOfApplication = By.XPath("//*[@id='candidateSearch_modeOfApplication']");

        By PDeleteBtn = By.XPath("//*[@id='btnDelete']");

        public PageCandidates(IWebDriver driver){
            this.driver = driver;
        }



        public void EnterName(){
            
            IWebElement candidate = driver.FindElement(Pcandidate);
            candidate.SendKeys("Nazar Andrushko");

        }

        public void EnterKeyWords(){
            IWebElement KeyWords = driver.FindElement(PKeyWords);
            KeyWords.SendKeys("SSomeKeyWords");
        }

        public void PickDateFrom(){
            IWebElement DateFrom = driver.FindElement(PDateOfApplicationFrom);
            DateFrom.Clear();
            DateFrom.SendKeys("2021-12-08");
        }

        public void Search(){
             IWebElement Seach_btn = driver.FindElement(PSearch_btn);
             Seach_btn.Click();

             // Check that element is added
             //Assert.AreEqual(ElementDisplayed(_USD), true);
        }
        public void Delete(){
            IWebElement CheckBox = driver.FindElement(By.XPath("//*[@id='ohrmList_chkSelectAll']"));
            CheckBox.Click();
            IWebElement DeleteBtn = driver.FindElement(PDeleteBtn);
            DeleteBtn.Click();
            IWebElement ConfirmDeleteBtn = driver.FindElement(By.XPath("//*[@id='dialogDeleteBtn']"));
            ConfirmDeleteBtn.Click();
        }



        public void execute(){
            this.EnterName();
            this.EnterKeyWords();
            this.PickDateFrom();
            this.Search();
            this.Delete();
        }
    };

    [TestFixture]
    class Program
    {

        [Test]
        public static void Main()
        {
           


            IWebDriver driver = new FirefoxDriver("/home/eingird/Study/csharp/WebApi");
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");

            // Work Shifts page
            System.Threading.Thread.Sleep(1000);
    
            IWebElement login = driver.FindElement(By.Id("txtUsername"));
            IWebElement password = driver.FindElement(By.Id("txtPassword"));
            
            login.SendKeys("Admin");
            password.SendKeys("admin123");
            
            IWebElement login_button = driver.FindElement(By.Id("btnLogin"));
            login_button.Click();

            IWebElement recruitment_module = driver.FindElement(By.Id("menu_recruitment_viewRecruitmentModule"));
      
            recruitment_module.Click();

            IWebElement Add_Btn = driver.FindElement(By.XPath("//*[@id='btnAdd']"));
            Add_Btn.Click();



            PageAddCandidates addCandidates = new PageAddCandidates(driver);
            addCandidates.execute();

            PageCandidates candidates = new PageCandidates(driver);
            candidates.execute();




    
            System.Threading.Thread.Sleep(50000);

            driver.Close();
        }
    }
}
