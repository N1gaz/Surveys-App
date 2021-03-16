--CREATE DATABASE SurveysApp

GO

USE SurveysApp

CREATE TABLE Surveys(
Id INT IDENTITY(1,1),
SurveyName NVARCHAR(100) NOT NULL,
PublishDateTime DATETIME DEFAULT GETDATE(),
SurveyDescription NVARCHAR(MAX),
CONSTRAINT PK_Surveys_Id PRIMARY KEY CLUSTERED (Id)
)

CREATE TABLE Questions(
Id INT IDENTITY(1,1),
SurveyId INT NOT NULL,
Number INT NOT NULL,
QuestionText NVARCHAR(MAX) NOT NULL,
IsMultipleAnswersSupports BIT NOT NULL,
CONSTRAINT PK_Questions_SurveyId_Number PRIMARY KEY (Id),
CONSTRAINT FK_Questions_Surveys_SurveyId FOREIGN KEY (SurveyId) REFERENCES Surveys (Id) ON DELETE CASCADE,
CONSTRAINT UK_Questions_SurveyId_Number UNIQUE (SurveyId, Number)
)

CREATE NONCLUSTERED INDEX SurveyId ON Questions(SurveyId)

CREATE TABLE Answers(
Id INT IDENTITY(1,1),
QuestionId INT NOT NULL,
AnswerText NVARCHAR(MAX) NOT NULL,
CONSTRAINT PK_Answers_Id PRIMARY KEY CLUSTERED (Id),
CONSTRAINT FK_Answers_Questions_Surveys_Id FOREIGN KEY (QuestionId) REFERENCES Questions (Id) ON DELETE CASCADE
)

CREATE NONCLUSTERED INDEX QuestionId ON Answers(QuestionId)

CREATE TABLE Interviews(
Id INT IDENTITY(1,1),
UserEmail NVARCHAR(256) DEFAULT '',
UserPhone NVARCHAR(15) DEFAULT '',
SurveyId INT NOT NULL,
PassDateTime DATETIME DEFAULT GETDATE(),
CONSTRAINT PK_Interviews_UserEmail_UserPhone_SurveyId PRIMARY KEY CLUSTERED (Id),
CONSTRAINT FK_Interviews_Suveys_SurveyId FOREIGN KEY (SurveyID) REFERENCES Surveys(Id) ON DELETE CASCADE,
CONSTRAINT CK_Interviews_UserEmail_UserPhone CHECK (UserEmail != '' AND UserPhone != ''),
CONSTRAINT UK_Interviews_UserEmail_SurveyId UNIQUE (UserEmail, SurveyId),
CONSTRAINT UK_Interviews_UserPhone_SurveyId UNIQUE (UserPhone, SurveyId)
)

CREATE NONCLUSTERED INDEX SurveyId ON Interviews(SurveyId)

CREATE TABLE Results(
AnswerId INT NOT NULL, 
InterviewId INT NOT NULL,
CONSTRAINT FK_Results_Answers_AnswerId FOREIGN KEY (AnswerId) REFERENCES Answers (Id),
CONSTRAINT FK_Results_Interview_ FOREIGN KEY (InterviewId) REFERENCES Interviews(Id)
)

CREATE NONCLUSTERED INDEX AnswerId ON Results(AnswerId)
CREATE NONCLUSTERED INDEX InterviewId ON Results(InterviewId)