USE [master]
GO
/****** Object:  Database [BOOTCAMPUS]    Script Date: 2022-09-28 오후 4:29:13 ******/
CREATE DATABASE [BOOTCAMPUS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BOOTCAMPUS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BOOTCAMPUS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BOOTCAMPUS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BOOTCAMPUS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BOOTCAMPUS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BOOTCAMPUS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BOOTCAMPUS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET ARITHABORT OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BOOTCAMPUS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BOOTCAMPUS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BOOTCAMPUS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BOOTCAMPUS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BOOTCAMPUS] SET  MULTI_USER 
GO
ALTER DATABASE [BOOTCAMPUS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BOOTCAMPUS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BOOTCAMPUS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BOOTCAMPUS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BOOTCAMPUS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BOOTCAMPUS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BOOTCAMPUS] SET QUERY_STORE = OFF
GO
USE [BOOTCAMPUS]
GO
/****** Object:  Table [dbo].[TB_BOARD]    Script Date: 2022-09-28 오후 4:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_BOARD](
	[BOARD_SEQ] [int] IDENTITY(1,1) NOT NULL,
	[STATE] [nvarchar](10) NOT NULL,
	[TITLE] [nvarchar](100) NOT NULL,
	[CONTENTS] [nvarchar](max) NOT NULL,
	[USER_ID] [nvarchar](10) NOT NULL,
	[WRITE_DATE] [datetime] NOT NULL,
	[VIEW_COUNT] [int] NOT NULL,
 CONSTRAINT [PK_TB_BOARD] PRIMARY KEY CLUSTERED 
(
	[BOARD_SEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_REPLY]    Script Date: 2022-09-28 오후 4:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_REPLY](
	[REPLY_SEQ] [int] IDENTITY(1,1) NOT NULL,
	[PARENT_SEQ] [int] NULL,
	[BOARD_SEQ] [int] NOT NULL,
	[REPLY_CONTENTS] [nvarchar](200) NOT NULL,
	[USER_ID] [nvarchar](10) NOT NULL,
	[WRITE_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TB_REPLY] PRIMARY KEY CLUSTERED 
(
	[REPLY_SEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TB_BOARD] ON 

INSERT [dbo].[TB_BOARD] ([BOARD_SEQ], [STATE], [TITLE], [CONTENTS], [USER_ID], [WRITE_DATE], [VIEW_COUNT]) VALUES (1, N'완료됨', N'View와 테이블의 차이점은?', N'내용1', N'오인주', CAST(N'2022-09-28T09:16:25.747' AS DateTime), 0)
INSERT [dbo].[TB_BOARD] ([BOARD_SEQ], [STATE], [TITLE], [CONTENTS], [USER_ID], [WRITE_DATE], [VIEW_COUNT]) VALUES (2, N'완료됨', N'STRING_SPLIT 함수 사용 시 공백문자가 구분자로 가능한가요?', N'내용2', N'최도일', CAST(N'2022-09-28T09:18:44.597' AS DateTime), 0)
INSERT [dbo].[TB_BOARD] ([BOARD_SEQ], [STATE], [TITLE], [CONTENTS], [USER_ID], [WRITE_DATE], [VIEW_COUNT]) VALUES (3, N'접수됨', N'제약조건의 종류는 어떤 것이 있나요?', N'수정 된 게시글 내용 3333', N'오인경', CAST(N'2022-09-28T10:04:06.633' AS DateTime), 4)
INSERT [dbo].[TB_BOARD] ([BOARD_SEQ], [STATE], [TITLE], [CONTENTS], [USER_ID], [WRITE_DATE], [VIEW_COUNT]) VALUES (4, N'진행중', N'Join 과 Sub Query의 차이점은 무엇인가요?', N'글내용 Join 과 Sub Query의 차이점은 무엇인가요????', N'박재상', CAST(N'2022-09-28T10:37:45.710' AS DateTime), 24)
INSERT [dbo].[TB_BOARD] ([BOARD_SEQ], [STATE], [TITLE], [CONTENTS], [USER_ID], [WRITE_DATE], [VIEW_COUNT]) VALUES (5, N'진행중', N'집계함수 중 가장 많이 사용되는 함수는 무엇인가요? ', N'글내용 집계함수 중 가장 많이 사용되는 함수는 무엇인가요? ', N'원상아', CAST(N'2022-09-28T10:38:16.307' AS DateTime), 16)
INSERT [dbo].[TB_BOARD] ([BOARD_SEQ], [STATE], [TITLE], [CONTENTS], [USER_ID], [WRITE_DATE], [VIEW_COUNT]) VALUES (6, N'오픈', N'SQL Sever를 다운받고 싶어요', N'글내용 SQL Sever를 다운받고 싶어요', N'고수임', CAST(N'2022-09-28T10:38:30.587' AS DateTime), 10)
INSERT [dbo].[TB_BOARD] ([BOARD_SEQ], [STATE], [TITLE], [CONTENTS], [USER_ID], [WRITE_DATE], [VIEW_COUNT]) VALUES (7, N'오픈', N'DB의 약자는 무엇인가요?', N'글내용 DB의 약자는 무엇인가요?', N'오혜석', CAST(N'2022-09-28T10:38:44.823' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[TB_BOARD] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_REPLY] ON 

INSERT [dbo].[TB_REPLY] ([REPLY_SEQ], [PARENT_SEQ], [BOARD_SEQ], [REPLY_CONTENTS], [USER_ID], [WRITE_DATE]) VALUES (1, NULL, 3, N'댓글1', N'김지영', CAST(N'2022-09-28T10:06:16.933' AS DateTime))
INSERT [dbo].[TB_REPLY] ([REPLY_SEQ], [PARENT_SEQ], [BOARD_SEQ], [REPLY_CONTENTS], [USER_ID], [WRITE_DATE]) VALUES (2, NULL, 3, N'댓글222222 수정수정', N'댓작성자2', CAST(N'2022-09-28T10:06:35.707' AS DateTime))
INSERT [dbo].[TB_REPLY] ([REPLY_SEQ], [PARENT_SEQ], [BOARD_SEQ], [REPLY_CONTENTS], [USER_ID], [WRITE_DATE]) VALUES (3, 1, 3, N'댓글1-1', N'댓작성자', CAST(N'2022-09-28T10:07:30.457' AS DateTime))
INSERT [dbo].[TB_REPLY] ([REPLY_SEQ], [PARENT_SEQ], [BOARD_SEQ], [REPLY_CONTENTS], [USER_ID], [WRITE_DATE]) VALUES (4, 1, 3, N'댓글1-2', N'댓작성자', CAST(N'2022-09-28T10:07:41.880' AS DateTime))
INSERT [dbo].[TB_REPLY] ([REPLY_SEQ], [PARENT_SEQ], [BOARD_SEQ], [REPLY_CONTENTS], [USER_ID], [WRITE_DATE]) VALUES (5, 2, 3, N'댓글2-1', N'댓작성자', CAST(N'2022-09-28T10:08:08.763' AS DateTime))
INSERT [dbo].[TB_REPLY] ([REPLY_SEQ], [PARENT_SEQ], [BOARD_SEQ], [REPLY_CONTENTS], [USER_ID], [WRITE_DATE]) VALUES (6, NULL, 3, N'댓글3333', N'댓작성자', CAST(N'2022-09-28T10:08:19.617' AS DateTime))
INSERT [dbo].[TB_REPLY] ([REPLY_SEQ], [PARENT_SEQ], [BOARD_SEQ], [REPLY_CONTENTS], [USER_ID], [WRITE_DATE]) VALUES (7, NULL, 4, N'저도 너무 궁금한 내용이에요', N'오인주', CAST(N'2022-09-11T00:00:00.000' AS DateTime))
INSERT [dbo].[TB_REPLY] ([REPLY_SEQ], [PARENT_SEQ], [BOARD_SEQ], [REPLY_CONTENTS], [USER_ID], [WRITE_DATE]) VALUES (8, NULL, 4, N'책을 읽어보세요', N'원상아', CAST(N'2022-09-13T00:00:00.000' AS DateTime))
INSERT [dbo].[TB_REPLY] ([REPLY_SEQ], [PARENT_SEQ], [BOARD_SEQ], [REPLY_CONTENTS], [USER_ID], [WRITE_DATE]) VALUES (9, 7, 4, N'저도저도 너무 궁금하네요', N'오인경', CAST(N'2022-09-28T10:42:05.473' AS DateTime))
SET IDENTITY_INSERT [dbo].[TB_REPLY] OFF
GO
ALTER TABLE [dbo].[TB_BOARD] ADD  CONSTRAINT [DF_TB_BOARD_WRITE_DATE]  DEFAULT (getdate()) FOR [WRITE_DATE]
GO
ALTER TABLE [dbo].[TB_BOARD] ADD  CONSTRAINT [DF_TB_BOARD_VIEW_COUNT]  DEFAULT ((0)) FOR [VIEW_COUNT]
GO
ALTER TABLE [dbo].[TB_REPLY] ADD  CONSTRAINT [DF_TB_REPLY_CREATE_DATE]  DEFAULT (getdate()) FOR [WRITE_DATE]
GO
ALTER TABLE [dbo].[TB_REPLY]  WITH CHECK ADD  CONSTRAINT [FK_TB_REPLY_TB_BOARD] FOREIGN KEY([BOARD_SEQ])
REFERENCES [dbo].[TB_BOARD] ([BOARD_SEQ])
GO
ALTER TABLE [dbo].[TB_REPLY] CHECK CONSTRAINT [FK_TB_REPLY_TB_BOARD]
GO
/****** Object:  StoredProcedure [dbo].[UP_BOOTCAMPUS_BOARD_C]    Script Date: 2022-09-28 오후 4:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* ==================================================== */
-- 설명 : 게시글 작성
-- 작성일 : 2022.09.28
-- 작성자 : 김지영
-------------------------------------------------------
-- EXEC UP_BOOTCAMPUS_BOARD_C '접수됨', '제약조건의 종류는 어떤 것이 있나요?', '게시글 내용444', '오인경'
/* ==================================================== */
CREATE PROCEDURE [dbo].[UP_BOOTCAMPUS_BOARD_C]
	@STATE NVARCHAR(10), -- 게시글 상태
	@TITLE NVARCHAR(100), -- 글 제목
	@CONTENTS NVARCHAR(MAX), -- 글 내용
	@USER_ID NVARCHAR(10) -- 작성자
AS
BEGIN
	INSERT INTO [dbo].[TB_BOARD]
	(
		[STATE]
        ,[TITLE]
        ,[CONTENTS]
        ,[USER_ID]
	)
    VALUES
	(
		@STATE,
		@TITLE,
		@CONTENTS,
		@USER_ID
	)
END
GO
/****** Object:  StoredProcedure [dbo].[UP_BOOTCAMPUS_BOARD_D]    Script Date: 2022-09-28 오후 4:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ==================================================== */
-- 설명 : 게시글 삭제
-- 작성일 : 2022.09.28
-- 작성자 : 김지영
-------------------------------------------------------
-- EXEC UP_BOOTCAMPUS_BOARD_D 3
/* ==================================================== */
CREATE PROCEDURE [dbo].[UP_BOOTCAMPUS_BOARD_D]
	@BOARD_SEQ INT
AS
BEGIN
	DELETE FROM [dbo].[TB_BOARD]
	WHERE BOARD_SEQ = @BOARD_SEQ
END
GO
/****** Object:  StoredProcedure [dbo].[UP_BOOTCAMPUS_BOARD_L]    Script Date: 2022-09-28 오후 4:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ==================================================== */
-- 설명 : 게시글 목록 조회
-- 작성일 : 2022.09.28
-- 작성자 : 김지영
-------------------------------------------------------
-- EXEC UP_BOOTCAMPUS_BOARD_L 
-- EXEC UP_BOOTCAMPUS_BOARD_L @STATE='접수됨'
-- EXEC UP_BOOTCAMPUS_BOARD_L @SEARCH_TYPE='제목', @SEARCH_WORD='제약조건'
-- EXEC UP_BOOTCAMPUS_BOARD_L @STATE='완료됨', @SEARCH_TYPE='작성자', @SEARCH_WORD='최도일'
-- EXEC UP_BOOTCAMPUS_BOARD_L @SEARCH_TYPE='제목', @SEARCH_WORD='?', @PAGE=3, @ROW_COUNT=2
/* ==================================================== */
CREATE PROCEDURE [dbo].[UP_BOOTCAMPUS_BOARD_L]
	@STATE NVARCHAR(10) = NULL, -- 게시글 상태(오픈, 접수됨, 진행중, 완료됨)
	@SEARCH_TYPE NVARCHAR(10) = NULL, -- 검색조건(제목, 내용, 번호, 작성자)
	@SEARCH_WORD NVARCHAR(50) = NULL, -- 검색어
	@PAGE INT = 1,
	@ROW_COUNT INT = 10
AS
BEGIN

	-- 페이징 처리를 위한 변수 선언
	DECLARE @START INT
	DECLARE @END INT

	-- 페이징 처리를 위한 값 세팅
	SET @START = (@PAGE - 1) * @ROW_COUNT + 1;
	SET @END = @PAGE * @ROW_COUNT;

	DECLARE @SQL NVARCHAR(MAX)
	DECLARE @WHERE NVARCHAR(MAX)
	DECLARE @PARAM NVARCHAR(MAX)

	SET @SQL = '
		SELECT 
			 ROW_NUMBER() OVER(ORDER BY BOARD_SEQ DESC) AS ROWNUM
			,[BOARD_SEQ]
			,[STATE]
			,[TITLE]
			,[USER_ID]
			,CONVERT(DATE, [WRITE_DATE], 20) AS [WRITE_DATE]
			,[VIEW_COUNT]
		FROM 
			[dbo].[TB_BOARD]
		WHERE 1=1
		'

	IF @STATE IS NOT NULL
	SET @SQL = @SQL + 'AND [STATE] = @P_STATE
	'

	IF @SEARCH_TYPE IS NOT NULL
	BEGIN
		IF @SEARCH_TYPE = '제목'
		BEGIN
			SET @SQL = @SQL + 'AND [TITLE] LIKE ''%'' + @P_SEARCH_WORD + ''%'''
		END
		ELSE IF @SEARCH_TYPE = '내용'
		BEGIN
			SET @SQL = @SQL + 'AND [CONTENTS] LIKE ''%'' + @P_SEARCH_WORD + ''%'''
		END
		ELSE IF @SEARCH_TYPE = '번호'
		BEGIN
			SET @SQL = @SQL + 'AND [BOARD_SEQ] = @P_SEARCH_WORD'
		END
		ELSE 
		IF @SEARCH_TYPE = '작성자'
		BEGIN
			SET @SQL = @SQL + 'AND [USER_ID] LIKE ''%'' + @P_SEARCH_WORD + ''%'''
		END
	END

	SET @SQL = '
	SELECT
		 [ROWNUM]
		,[BOARD_SEQ]
		,[STATE]
		,[TITLE]
		,[USER_ID]
		,[WRITE_DATE]
		,[VIEW_COUNT]
	FROM 
	(' 
	+ @SQL + 
	') AS BOARD
	WHERE ROWNUM BETWEEN @P_START AND @P_END'

	SET @PARAM = '
	@P_STATE NVARCHAR(10),
	@P_SEARCH_WORD NVARCHAR(50),
	@P_START INT,
	@P_END INT
	'
	EXEC sp_executesql	@SQL, 
						@PARAM,
						@P_STATE = @STATE,
						@P_SEARCH_WORD = @SEARCH_WORD,
						@P_START = @START,
						@P_END = @END
	PRINT @SQL
END
GO
/****** Object:  StoredProcedure [dbo].[UP_BOOTCAMPUS_BOARD_R]    Script Date: 2022-09-28 오후 4:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ==================================================== */
-- 설명 : 게시글 내용 상세 조회
-- 작성일 : 2022.09.28
-- 작성자 : 김지영
-------------------------------------------------------
-- EXEC UP_BOOTCAMPUS_BOARD_R 3
/* ==================================================== */
CREATE PROCEDURE [dbo].[UP_BOOTCAMPUS_BOARD_R]
	@BOARD_SEQ INT
AS
BEGIN
	-- 조회 수 증가
	UPDATE [dbo].[TB_BOARD]
	SET [VIEW_COUNT] = [VIEW_COUNT]  + 1
	WHERE BOARD_SEQ = @BOARD_SEQ

	-- 상세 내용 조회
	SELECT 
		 [BOARD_SEQ]
		,CONCAT('[', [STATE], '] ', [TITLE]) AS [TITLE]
		,[CONTENTS]
		,[USER_ID]
		,[WRITE_DATE]
		,[VIEW_COUNT]
	FROM 
		[dbo].[TB_BOARD]
	WHERE
		BOARD_SEQ = @BOARD_SEQ

	-- 댓글 조회
	EXEC UP_BOOTCAMPUS_REPLY_L @BOARD_SEQ
END
GO
/****** Object:  StoredProcedure [dbo].[UP_BOOTCAMPUS_BOARD_U]    Script Date: 2022-09-28 오후 4:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ==================================================== */
-- 설명 : 게시글 수정
-- 작성일 : 2022.09.28
-- 작성자 : 김지영
-------------------------------------------------------
-- EXEC UP_BOOTCAMPUS_BOARD_U 3, '접수됨', '제약조건의 종류는 어떤 것이 있나요?', '수정 된 게시글 내용 3333', '오인경'
/* ==================================================== */
CREATE PROCEDURE [dbo].[UP_BOOTCAMPUS_BOARD_U]
	@BOARD_SEQ INT,	-- 게시글 번호
	@STATE NVARCHAR(10), -- 게시글 상태
	@TITLE NVARCHAR(100), -- 글 제목
	@CONTENTS NVARCHAR(MAX), -- 글 내용
	@USER_ID NVARCHAR(10) -- 작성자
AS
BEGIN
	UPDATE [dbo].[TB_BOARD]
	SET 
		 [STATE] = @STATE
		,[TITLE] = @TITLE
		,[CONTENTS] = @CONTENTS
		,[USER_ID] = @USER_ID
	WHERE 
		BOARD_SEQ = @BOARD_SEQ
END
GO
/****** Object:  StoredProcedure [dbo].[UP_BOOTCAMPUS_REPLY_C]    Script Date: 2022-09-28 오후 4:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ==================================================== */
-- 설명 : 댓글 작성
-- 작성일 : 2022.09.28
-- 작성자 : 김지영
-------------------------------------------------------
-- EXEC UP_BOOTCAMPUS_REPLY_C @BOARD_SEQ=3, @REPLY_CONTENTS='댓글3333', @USER_ID='댓작성자'
-- EXEC UP_BOOTCAMPUS_REPLY_C @BOARD_SEQ=4, @PARENT_SEQ=7, @REPLY_CONTENTS='저도저도 너무 궁금하네요', @USER_ID='오인경'
/* ==================================================== */
CREATE PROCEDURE [dbo].[UP_BOOTCAMPUS_REPLY_C]
	 @PARENT_SEQ INT = NULL
    ,@BOARD_SEQ INT
    ,@REPLY_CONTENTS NVARCHAR(200)
    ,@USER_ID NVARCHAR(10)
AS
BEGIN
	INSERT INTO [dbo].[TB_REPLY]
           ([PARENT_SEQ]
           ,[BOARD_SEQ]
           ,[REPLY_CONTENTS]
           ,[USER_ID])
     VALUES
           (@PARENT_SEQ
           ,@BOARD_SEQ
           ,@REPLY_CONTENTS
           ,@USER_ID)
END
GO
/****** Object:  StoredProcedure [dbo].[UP_BOOTCAMPUS_REPLY_D]    Script Date: 2022-09-28 오후 4:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ==================================================== */
-- 설명 : 댓글 삭제
-- 작성일 : 2022.09.28
-- 작성자 : 김지영
-------------------------------------------------------
-- EXEC UP_BOOTCAMPUS_REPLY_D 2
/* ==================================================== */
CREATE PROCEDURE [dbo].[UP_BOOTCAMPUS_REPLY_D]
	@REPLY_SEQ INT
AS
BEGIN
	DELETE FROM [dbo].[TB_REPLY]
	WHERE [REPLY_SEQ] = @REPLY_SEQ
END
GO
/****** Object:  StoredProcedure [dbo].[UP_BOOTCAMPUS_REPLY_D2]    Script Date: 2022-09-28 오후 4:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ==================================================== */
-- 설명 : 전체 댓글 삭제(게시글 삭제 시, 전체 댓글 삭제)
-- 작성일 : 2022.09.28
-- 작성자 : 김지영
-------------------------------------------------------
-- EXEC UP_BOOTCAMPUS_REPLY_D2 2
/* ==================================================== */
CREATE PROCEDURE [dbo].[UP_BOOTCAMPUS_REPLY_D2]
	@BOARD_SEQ INT
AS
BEGIN
	DELETE FROM [dbo].[TB_REPLY]
	WHERE [BOARD_SEQ] = @BOARD_SEQ
END
GO
/****** Object:  StoredProcedure [dbo].[UP_BOOTCAMPUS_REPLY_L]    Script Date: 2022-09-28 오후 4:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ==================================================== */
-- 설명 : 댓글 조회
-- 작성일 : 2022.09.28
-- 작성자 : 김지영
-------------------------------------------------------
-- EXEC UP_BOOTCAMPUS_REPLY_L 4
/* ==================================================== */
CREATE PROCEDURE [dbo].[UP_BOOTCAMPUS_REPLY_L]
	@BOARD_SEQ INT
AS
BEGIN
	WITH CTE_REPLY([REPLY_SEQ], [PARENT_SEQ], [BOARD_SEQ], [REPLY_CONTENTS], [USER_ID], [CREATE_DATE], [LEVEL])
	AS
	(
		SELECT [REPLY_SEQ], [PARENT_SEQ], [BOARD_SEQ], [REPLY_CONTENTS], [USER_ID], [WRITE_DATE], 0 AS [LEVEL]
		FROM [dbo].[TB_REPLY]
		WHERE [BOARD_SEQ] = @BOARD_SEQ AND [PARENT_SEQ] IS NULL

		UNION ALL

		SELECT R.[REPLY_SEQ], R.[PARENT_SEQ], R.[BOARD_SEQ], R.[REPLY_CONTENTS], R.[USER_ID], R.[WRITE_DATE], C.[LEVEL] + 1
		FROM [dbo].[TB_REPLY] R INNER JOIN CTE_REPLY C ON C.REPLY_SEQ = R.PARENT_SEQ 
		WHERE R.[BOARD_SEQ] = @BOARD_SEQ
	)
	SELECT [REPLY_SEQ], [PARENT_SEQ], [BOARD_SEQ], [REPLY_CONTENTS], [USER_ID], [CREATE_DATE], [LEVEL]
	FROM CTE_REPLY
	ORDER BY [LEVEL], [CREATE_DATE]
END
GO
/****** Object:  StoredProcedure [dbo].[UP_BOOTCAMPUS_REPLY_U]    Script Date: 2022-09-28 오후 4:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ==================================================== */
-- 설명 : 댓글 수정
-- 작성일 : 2022.09.28
-- 작성자 : 김지영
-------------------------------------------------------
-- EXEC UP_BOOTCAMPUS_REPLY_U @REPLY_SEQ=2, @REPLY_CONTENTS='댓글222222 수정수정'
/* ==================================================== */
CREATE PROCEDURE [dbo].[UP_BOOTCAMPUS_REPLY_U]
     @REPLY_SEQ INT
    ,@REPLY_CONTENTS NVARCHAR(200)
AS
BEGIN
	UPDATE [dbo].[TB_REPLY]
	SET [REPLY_CONTENTS] = @REPLY_CONTENTS
	WHERE [REPLY_SEQ] = @REPLY_SEQ
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'게시글 번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_BOARD', @level2type=N'COLUMN',@level2name=N'BOARD_SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'게시글 상태(오픈, 접수됨, 진행중, 완료됨)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_BOARD', @level2type=N'COLUMN',@level2name=N'STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'제목' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_BOARD', @level2type=N'COLUMN',@level2name=N'TITLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'작성자 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_BOARD', @level2type=N'COLUMN',@level2name=N'USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'작성일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_BOARD', @level2type=N'COLUMN',@level2name=N'WRITE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'조회수' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_BOARD', @level2type=N'COLUMN',@level2name=N'VIEW_COUNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'댓글 번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_REPLY', @level2type=N'COLUMN',@level2name=N'REPLY_SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'상위댓글의 번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_REPLY', @level2type=N'COLUMN',@level2name=N'PARENT_SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'게시글 번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_REPLY', @level2type=N'COLUMN',@level2name=N'BOARD_SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'댓글내용' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_REPLY', @level2type=N'COLUMN',@level2name=N'REPLY_CONTENTS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'댓글 작성자 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_REPLY', @level2type=N'COLUMN',@level2name=N'USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'작성일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_REPLY', @level2type=N'COLUMN',@level2name=N'WRITE_DATE'
GO
USE [master]
GO
ALTER DATABASE [BOOTCAMPUS] SET  READ_WRITE 
GO
