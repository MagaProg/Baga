CREATE TABLE [dbo].[Table] (
    [id]                   INT           IDENTITY (1, 1) NOT NULL ,
    [Клиент]               NVARCHAR (MAX) NULL ,
    [Тип]                  NVARCHAR (MAX) NULL ,
    [Производитель]        NVARCHAR (MAX) NULL ,
    [Модель]               NVARCHAR (MAX) NULL ,
    [SN]                   NVARCHAR (MAX) NULL ,
    [Описниенеисправности] NVARCHAR (MAX) NULL ,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

