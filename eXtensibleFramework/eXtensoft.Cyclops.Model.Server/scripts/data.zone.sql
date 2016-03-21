
SET IDENTITY_INSERT [dbo].[Zone] ON 

GO
INSERT [dbo].[Zone] ([ZoneId], [Name], [Alias], [Token]) VALUES (0, N'None', N'None', N'no-zone')
GO
INSERT [dbo].[Zone] ([ZoneId], [Name], [Alias], [Token]) VALUES (1, N'Local', N'Local', N'local')
GO
INSERT [dbo].[Zone] ([ZoneId], [Name], [Alias], [Token]) VALUES (2, N'Development', N'Dev', N'development')
GO
INSERT [dbo].[Zone] ([ZoneId], [Name], [Alias], [Token]) VALUES (3, N'QA', N'QA', N'qa')
GO
INSERT [dbo].[Zone] ([ZoneId], [Name], [Alias], [Token]) VALUES (4, N'UAT', N'UAT', N'uat')
GO
INSERT [dbo].[Zone] ([ZoneId], [Name], [Alias], [Token]) VALUES (5, N'Integration', N'Integration', N'integration')
GO
INSERT [dbo].[Zone] ([ZoneId], [Name], [Alias], [Token]) VALUES (6, N'Partner', N'Partner', N'partner')
GO
INSERT [dbo].[Zone] ([ZoneId], [Name], [Alias], [Token]) VALUES (7, N'Staging', N'Staging', N'staging')
GO
INSERT [dbo].[Zone] ([ZoneId], [Name], [Alias], [Token]) VALUES (8, N'Production', N'Prod', N'production')
GO
SET IDENTITY_INSERT [dbo].[Zone] OFF
GO