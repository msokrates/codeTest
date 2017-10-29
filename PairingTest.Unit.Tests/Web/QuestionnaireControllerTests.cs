using NUnit.Framework;
using PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using QuestionServiceWebApi;
using Moq;
using PairingTest.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "My expected questions";
            var mockedHttpClientWrapper = new Mock<IHttpClientWrapper>();
            var questions = new List<string>() { "Question 1", "Question 2" };
            var questionnaire = new Questionnaire
            {
                QuestionnaireTitle = expectedTitle,
                QuestionsText = questions
            };
            var serialisedQuestionnaire = new JavaScriptSerializer().Serialize(questionnaire);
            mockedHttpClientWrapper.Setup(client => client.Get(It.IsAny<string>())).Returns(serialisedQuestionnaire);

            var questionnaireController = new QuestionnaireController(mockedHttpClientWrapper.Object);

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;
            
            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            Assert.That(result.QuestionsText.Count, Is.EqualTo(2));
            Assert.That(result.QuestionsText[0], Is.EqualTo(questions[0]));
            Assert.That(result.QuestionsText[1], Is.EqualTo(questions[1]));
        }
    }
}