# Host: localhost  (Version 5.6.41-log)
# Date: 2019-10-12 09:07:15
# Generator: MySQL-Front 6.0  (Build 2.20)


#
# Structure for table "base"
#

DROP TABLE IF EXISTS `base`;
CREATE TABLE `base` (
  `ObjectID` varchar(50) DEFAULT NULL,
  `Remark` varchar(500) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedTime` timestamp NULL DEFAULT NULL,
  `ModifiedBy` varchar(50) DEFAULT NULL,
  `ModifiedTime` timestamp NULL DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

#
# Data for table "base"
#


#
# Structure for table "post"
#

DROP TABLE IF EXISTS `post`;
CREATE TABLE `post` (
  `ObjectId` char(10) DEFAULT NULL,
  `Title` char(10) DEFAULT NULL,
  `Content` char(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

#
# Data for table "post"
#


#
# Structure for table "r_rolepermission"
#

DROP TABLE IF EXISTS `r_rolepermission`;
CREATE TABLE `r_rolepermission` (
  `ObjectID` varchar(50) DEFAULT NULL,
  `RoleID` varchar(50) DEFAULT NULL,
  `MenuID` varchar(50) DEFAULT NULL,
  `FunctionID` varchar(50) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedTime` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

#
# Data for table "r_rolepermission"
#

INSERT INTO `r_rolepermission` VALUES ('04796b12-a605-47f2-ad43-2a1465a379af','7D6DF740-6213-4F99-A04F-FE489522B103','A6DC65C3-861B-421F-A192-8DBAA31351D5','8ee15d16-fed1-4338-a4dc-bd83fedf4191','系统管理员','2019-05-27 11:06:25'),('0a7d0bef-2061-439d-b525-4415e3742354','7D6DF740-6213-4F99-A04F-FE489522B103','4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','A1C11208-B87A-4BB9-BFF5-B0E580BA1A6D','系统管理员','2019-05-27 11:06:25'),('0f56e83d-9c57-4ec5-9ac7-432dea72ace6','7D6DF740-6213-4F99-A04F-FE489522B103','A6DC65C3-861B-421F-A192-8DBAA31351D5','E13DA120-41FE-4CAC-9F47-BEAC0629DEA2','系统管理员','2019-05-27 11:06:25'),('12b8aacf-badf-423c-8cd1-6123af46fe2b','7D6DF740-6213-4F99-A04F-FE489522B103','2a164811-380c-4170-8f8a-783b921e1aab','4ff1ffcb-2f93-4506-94c0-212800a9532c','系统管理员','2019-05-27 11:06:25'),('19e3ce47-6c15-458b-858b-978bf40fc440','7D6DF740-6213-4F99-A04F-FE489522B103','4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','586c60db-090f-4e1f-a4db-cd97edbdf2ac','系统管理员','2019-05-27 11:06:25'),('23e0111a-bda6-45cc-ba4d-ab9eee3ebe6c','7D6DF740-6213-4F99-A04F-FE489522B103','d1c96976-25a5-4a0a-87a4-0fcb6c5017ef','6bd5b10d-dc44-4718-85d0-3653e48e6d34','系统管理员','2019-05-27 11:06:25'),('3109cf71-c35f-4cfd-a61d-9ac0c47c61fa','99BBFB26-5521-4BE5-99C0-0B8161335388','da6f1b62-186f-4828-bcf4-9c1dba16382a','da6f1b62-186f-4828-bcf4-9c1dba16382a','系统管理员','2019-05-22 17:09:13'),('31e8e434-81a6-47a0-9dcd-af91d4a608d4','7D6DF740-6213-4F99-A04F-FE489522B103','da6f1b62-186f-4828-bcf4-9c1dba16382a','da6f1b62-186f-4828-bcf4-9c1dba16382a','系统管理员','2019-05-27 11:06:25'),('379facd5-985b-4ee1-9308-83dd12cf8084','99BBFB26-5521-4BE5-99C0-0B8161335388','da8bb150-2a7a-49c9-aa34-2b27c621ae5a','a50cd4e3-037d-46b7-b3aa-a8e7b7d1f88b','系统管理员','2019-05-22 17:09:13'),('3e1e5e31-4b96-4b9c-aa49-cdb84c5b1d7d','7D6DF740-6213-4F99-A04F-FE489522B103','4ed7719a-ea86-4b81-8929-8203978c18d9','4ed7719a-ea86-4b81-8929-8203978c18d9','系统管理员','2019-05-27 11:06:25'),('45733adf-5953-4dc4-b935-fe26c20e22d9','7D6DF740-6213-4F99-A04F-FE489522B103','3ca4b32b-30cc-4040-b6ac-34ac47059b78','823cd586-6995-474f-8123-7311e34fe7c6','系统管理员','2019-05-27 11:06:25'),('49a94483-cb6f-4861-8503-84fc08ba07f6','7D6DF740-6213-4F99-A04F-FE489522B103','da8bb150-2a7a-49c9-aa34-2b27c621ae5a','a50cd4e3-037d-46b7-b3aa-a8e7b7d1f88b','系统管理员','2019-05-27 11:06:25'),('4a8c199c-0e79-40ed-b06b-774d9bc51e7e','99BBFB26-5521-4BE5-99C0-0B8161335388','d1c96976-25a5-4a0a-87a4-0fcb6c5017ef','d1c96976-25a5-4a0a-87a4-0fcb6c5017ef','系统管理员','2019-05-22 17:09:13'),('4ee98b03-01e5-4b2a-b87f-8a7ff5a5e87e','7D6DF740-6213-4F99-A04F-FE489522B103','A6DC65C3-861B-421F-A192-8DBAA31351D5','d379fca8-3440-423d-8a0a-4eb0639d25a3','系统管理员','2019-05-27 11:06:25'),('4f41e365-eff4-4964-85c8-d954ec0f7362','7D6DF740-6213-4F99-A04F-FE489522B103','9dc4bce0-ca40-4cc2-ab61-927b7e247b8c','c5f38301-c712-4f73-80d1-f43d65508834','系统管理员','2019-05-27 11:06:25'),('4f6fc1ca-819e-4bb7-8451-ce080693b1fc','99BBFB26-5521-4BE5-99C0-0B8161335388','4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','C26CFB95-A74F-4793-A5CF-F7F75A195771','系统管理员','2019-05-22 17:09:13'),('5506228d-dd1b-4531-864d-31d4f9869a73','7D6DF740-6213-4F99-A04F-FE489522B103','A6DC65C3-861B-421F-A192-8DBAA31351D5','f721a1e5-a346-4d5a-91f3-5ca7ff07dfb2','系统管理员','2019-05-27 11:06:25'),('57db1e3d-9639-4e0f-8df3-79c5ccaa102c','7D6DF740-6213-4F99-A04F-FE489522B103','d1c96976-25a5-4a0a-87a4-0fcb6c5017ef','87c35702-b37f-4e5d-b8c7-0432d5b33cb6','系统管理员','2019-05-27 11:06:25'),('5925b126-03a7-424f-bfb2-2bbba6d9340e','7D6DF740-6213-4F99-A04F-FE489522B103','8809e432-1fc9-43e5-b3da-8ce6b488e04f','ea1dd383-80c6-4087-84af-5b6124cdbd3f','系统管理员','2019-05-27 11:06:25'),('5c92de74-3586-411a-93a6-190badcf7e54','99BBFB26-5521-4BE5-99C0-0B8161335388','4ed7719a-ea86-4b81-8929-8203978c18d9','4ed7719a-ea86-4b81-8929-8203978c18d9','系统管理员','2019-05-22 17:09:13'),('650d4bf8-eb33-481f-833f-4d91cec7f951','7D6DF740-6213-4F99-A04F-FE489522B103','2a164811-380c-4170-8f8a-783b921e1aab','ad064726-9c82-463b-b415-fa45ac78a7a2','系统管理员','2019-05-27 11:06:25'),('656b1f50-ee61-418d-b5a7-6356eb4ddf3c','7D6DF740-6213-4F99-A04F-FE489522B103','9dc4bce0-ca40-4cc2-ab61-927b7e247b8c','a5605de9-22a9-44c7-ace1-ffa8891179aa','系统管理员','2019-05-27 11:06:25'),('6782c575-339e-42ec-afdf-eb738eee0543','99BBFB26-5521-4BE5-99C0-0B8161335388','d1c96976-25a5-4a0a-87a4-0fcb6c5017ef','6bd5b10d-dc44-4718-85d0-3653e48e6d34','系统管理员','2019-05-22 17:09:13'),('78838e41-8eb5-43b3-a715-baf6a7a28c70','99BBFB26-5521-4BE5-99C0-0B8161335388','8809e432-1fc9-43e5-b3da-8ce6b488e04f','3750ba8c-4c9a-4cb7-a016-56691890f75e','系统管理员','2019-05-22 17:09:13'),('7c6116b9-98a2-486e-9b71-c5c271eeb005','7D6DF740-6213-4F99-A04F-FE489522B103','3ca4b32b-30cc-4040-b6ac-34ac47059b78','9bb79d19-1dc8-4030-8669-2d12c70ea23d','系统管理员','2019-05-27 11:06:25'),('81b78536-bd56-455d-a954-9f96b06f3aee','7D6DF740-6213-4F99-A04F-FE489522B103','2a164811-380c-4170-8f8a-783b921e1aab','1fac9225-c1ae-44f1-bec0-f0175a069452','系统管理员','2019-05-27 11:06:25'),('879806ea-e117-43fb-a367-8a5a12282816','7D6DF740-6213-4F99-A04F-FE489522B103','d1c96976-25a5-4a0a-87a4-0fcb6c5017ef','d1c96976-25a5-4a0a-87a4-0fcb6c5017ef','系统管理员','2019-05-27 11:06:25'),('87a1b64e-8607-41ac-9044-c4ce1db7ee79','7D6DF740-6213-4F99-A04F-FE489522B103','2a164811-380c-4170-8f8a-783b921e1aab','b916c45a-278d-4f9c-a5a5-6f986be9c6fa','系统管理员','2019-05-27 11:06:25'),('9056c632-bec7-4631-9da8-87c4afbd7abb','7D6DF740-6213-4F99-A04F-FE489522B103','C7FD9389-2D50-47A7-AB59-510C7B49F570','C7FD9389-2D50-47A7-AB59-510C7B49F570','系统管理员','2019-05-27 11:06:25'),('923c6ef9-af95-4747-b720-6aa056ec6f50','99BBFB26-5521-4BE5-99C0-0B8161335388','C7FD9389-2D50-47A7-AB59-510C7B49F570','C7FD9389-2D50-47A7-AB59-510C7B49F570','系统管理员','2019-05-22 17:09:13'),('949a9976-e399-4795-ac15-91d8a515d9f7','7D6DF740-6213-4F99-A04F-FE489522B103','A6DC65C3-861B-421F-A192-8DBAA31351D5','D8E4E550-DF97-41C9-82A4-FF4ACDE5C8A2','系统管理员','2019-05-27 11:06:25'),('a13ebea2-8127-4532-bb6e-d119dbda786b','7D6DF740-6213-4F99-A04F-FE489522B103','A6DC65C3-861B-421F-A192-8DBAA31351D5','5d392560-d767-44c1-8967-f88ac3566d69','系统管理员','2019-05-27 11:06:25'),('af27f0a2-863e-49e2-bd97-9d4c0ad89f59','7D6DF740-6213-4F99-A04F-FE489522B103','4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','C26CFB95-A74F-4793-A5CF-F7F75A195771','系统管理员','2019-05-27 11:06:25'),('b104c281-35a1-49c1-b23d-7e7a03f6d618','7D6DF740-6213-4F99-A04F-FE489522B103','9dc4bce0-ca40-4cc2-ab61-927b7e247b8c','a8457fb7-3909-4680-a994-ac46bd0e4792','系统管理员','2019-05-27 11:06:25'),('b195b5e3-148e-4a31-8fc5-e5daadcaa771','7D6DF740-6213-4F99-A04F-FE489522B103','4e828c7f-9c2b-4a55-9eb5-ab461bd6a267','4e828c7f-9c2b-4a55-9eb5-ab461bd6a267','系统管理员','2019-05-27 11:06:25'),('b836f789-7f23-472a-883f-b7644b19a8b8','99BBFB26-5521-4BE5-99C0-0B8161335388','3ca4b32b-30cc-4040-b6ac-34ac47059b78','823cd586-6995-474f-8123-7311e34fe7c6','系统管理员','2019-05-22 17:09:13'),('b8b4de8f-71cc-47f1-8415-90245ce816d4','7D6DF740-6213-4F99-A04F-FE489522B103','2d37fe44-fa0b-49ec-b297-fd476405f020','2d37fe44-fa0b-49ec-b297-fd476405f020','系统管理员','2019-05-27 11:06:25'),('bea4de7b-01dc-4e00-b5d9-5b8d38a99b34','99BBFB26-5521-4BE5-99C0-0B8161335388','4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','A1C11208-B87A-4BB9-BFF5-B0E580BA1A6D','系统管理员','2019-05-22 17:09:13'),('cc96493b-dda0-40f5-afee-f1ceee76b463','7D6DF740-6213-4F99-A04F-FE489522B103','8809e432-1fc9-43e5-b3da-8ce6b488e04f','3750ba8c-4c9a-4cb7-a016-56691890f75e','系统管理员','2019-05-27 11:06:25'),('cdecbeac-e4fd-4bad-8ef1-036154903145','99BBFB26-5521-4BE5-99C0-0B8161335388','d1c96976-25a5-4a0a-87a4-0fcb6c5017ef','87c35702-b37f-4e5d-b8c7-0432d5b33cb6','系统管理员','2019-05-22 17:09:13'),('d205b9bc-9722-470d-87c5-148779624e70','99BBFB26-5521-4BE5-99C0-0B8161335388','3ca4b32b-30cc-4040-b6ac-34ac47059b78','9bb79d19-1dc8-4030-8669-2d12c70ea23d','系统管理员','2019-05-22 17:09:13'),('d2f48ec5-89b5-4d00-8257-6fad7a3cd26b','7D6DF740-6213-4F99-A04F-FE489522B103','4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','0afd5d0d-61e5-413f-a006-6dce4803bdf3','系统管理员','2019-05-27 11:06:25'),('d696e378-5a6c-4d41-8a38-1df051eefbd8','7D6DF740-6213-4F99-A04F-FE489522B103','2a164811-380c-4170-8f8a-783b921e1aab','5346eb82-d3a4-438a-8b27-0337c896a213','系统管理员','2019-05-27 11:06:25'),('d8313689-bef5-4a63-8cd5-b0e9eb131d31','7D6DF740-6213-4F99-A04F-FE489522B103','A6DC65C3-861B-421F-A192-8DBAA31351D5','60cf5000-cb37-4033-8a7f-23e917b03fc2','系统管理员','2019-05-27 11:06:25'),('e1fdba62-9707-47b6-82d5-36000ef9f578','7D6DF740-6213-4F99-A04F-FE489522B103','4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','fede2115-0d6a-412c-a177-05ae3380e7f1','系统管理员','2019-05-27 11:06:25'),('f3b53d57-8dd7-4d11-a61e-c646761f9f4f','7D6DF740-6213-4F99-A04F-FE489522B103','A6DC65C3-861B-421F-A192-8DBAA31351D5','3f4dbc36-45c5-4080-975e-99e82f2ca1ba','系统管理员','2019-05-27 11:06:25'),('f50d153c-01e8-4c6b-98f0-533e05c678b4','7D6DF740-6213-4F99-A04F-FE489522B103','9dc4bce0-ca40-4cc2-ab61-927b7e247b8c','2e0bcacf-c3f4-4b14-84fb-50e3a6b7ce54','系统管理员','2019-05-27 11:06:25'),('ff01d8f4-d8bf-487a-9c54-0e51058c37f6','99BBFB26-5521-4BE5-99C0-0B8161335388','2d37fe44-fa0b-49ec-b297-fd476405f020','2d37fe44-fa0b-49ec-b297-fd476405f020','系统管理员','2019-05-22 17:09:13');

#
# Structure for table "r_sysuserinfo_sysrole"
#

DROP TABLE IF EXISTS `r_sysuserinfo_sysrole`;
CREATE TABLE `r_sysuserinfo_sysrole` (
  `ObjectID` varchar(50) DEFAULT NULL,
  `UserInfoID` varchar(50) DEFAULT NULL,
  `RoleID` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

#
# Data for table "r_sysuserinfo_sysrole"
#

INSERT INTO `r_sysuserinfo_sysrole` VALUES ('2da70f2c-7232-488f-8ab8-6e65e610f73e','D451D121-0AA5-4ECF-BD2A-2CDA443F795D','99BBFB26-5521-4BE5-99C0-0B8161335388'),('9997b3a6-2b49-4312-b291-2c307563baa3','3FDC2296-8D1E-43CD-BBF3-4CA0FAF67005','7D6DF740-6213-4F99-A04F-FE489522B103');

#
# Structure for table "r_userpermissions"
#

DROP TABLE IF EXISTS `r_userpermissions`;
CREATE TABLE `r_userpermissions` (
  `ObjectID` varchar(50) DEFAULT NULL,
  `UserID` varchar(50) DEFAULT NULL,
  `MenuID` varchar(50) DEFAULT NULL,
  `FunctionID` varchar(50) DEFAULT NULL,
  `HavePermission` int(11) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedTime` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

#
# Data for table "r_userpermissions"
#


#
# Structure for table "sysfunction"
#

DROP TABLE IF EXISTS `sysfunction`;
CREATE TABLE `sysfunction` (
  `ObjectID` varchar(50) DEFAULT NULL,
  `FName` varchar(50) DEFAULT NULL,
  `FFunction` varchar(50) DEFAULT NULL,
  `FURL` varchar(200) DEFAULT NULL,
  `FIcon` varchar(50) DEFAULT NULL,
  `ParentID` varchar(50) DEFAULT NULL,
  `Remark` varchar(500) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedTime` timestamp NULL DEFAULT NULL,
  `ModifiedBy` varchar(50) DEFAULT NULL,
  `ModifiedTime` timestamp NULL DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

#
# Data for table "sysfunction"
#

INSERT INTO `sysfunction` VALUES ('0afd5d0d-61e5-413f-a006-6dce4803bdf3','设置角色','SetRole','/Admin/UserInfo/SetRole','layui-icon layui-icon-set-fill','4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','设置角色',0,'系统管理员','2019-05-20 17:46:38','系统管理员','2019-05-21 14:44:46',50),('1fac9225-c1ae-44f1-bec0-f0175a069452','查看','Index','/Admin/Role/Index','fa fa-eye','2a164811-380c-4170-8f8a-783b921e1aab','查看权限',0,'系统管理员','2019-05-14 15:48:18','系统管理员','2019-05-21 14:52:42',10),('2e0bcacf-c3f4-4b14-84fb-50e3a6b7ce54','新增或编辑','Form','/WorkFlow/Home/Form','layui-icon layui-icon-search','9dc4bce0-ca40-4cc2-ab61-927b7e247b8c','新增或编辑',0,'系统管理员','2019-05-24 15:49:24',NULL,NULL,30),('3750ba8c-4c9a-4cb7-a016-56691890f75e','查看','Index',NULL,'layui-icon layui-icon-search','8809e432-1fc9-43e5-b3da-8ce6b488e04f','查看权限',0,'系统管理员','2019-05-14 16:47:28',NULL,NULL,1),('3f4dbc36-45c5-4080-975e-99e82f2ca1ba','权限项设置页面','Index','/Admin/Function/Index','layui-icon layui-icon-set-fill','A6DC65C3-861B-421F-A192-8DBAA31351D5','权限项设置',0,'系统管理员','2019-05-21 14:48:37','系统管理员','2019-05-21 14:48:51',50),('4f68837e-1bdb-489a-bc71-c091cf1d5d99','生成代码','BuildCode','/Admin/RapidDevelopment/BuildCode','layui-icon layui-icon-app','C7EC2A0B-BC81-40ED-9595-25840091F197','生成代码',0,'系统管理员','2019-05-21 11:05:48','系统管理员','2019-05-21 14:54:03',30),('4ff1ffcb-2f93-4506-94c0-212800a9532c','查询列表','List','/Admin/Role/List','layui-icon layui-icon-search','2a164811-380c-4170-8f8a-783b921e1aab','查询列表',0,'系统管理员','2019-05-14 15:48:18','系统管理员','2019-05-21 14:52:51',20),('5346eb82-d3a4-438a-8b27-0337c896a213','新增或编辑','Form','/Admin/Role/Form','layui-icon layui-icon-edit','2a164811-380c-4170-8f8a-783b921e1aab','新增或编辑',0,'系统管理员','2019-05-21 10:55:41','系统管理员','2019-05-21 14:52:58',30),('586c60db-090f-4e1f-a4db-cd97edbdf2ac','删除','Delete','/Admin/UserInfo/Delete','layui-icon layui-icon-delete','4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','删除',0,'系统管理员','2019-05-20 17:45:28','系统管理员','2019-05-21 14:44:37',40),('5d392560-d767-44c1-8967-f88ac3566d69','权限项查询列表','List','/Admin/Function/List','layui-icon layui-icon-search','A6DC65C3-861B-421F-A192-8DBAA31351D5','权限项查询列表',0,'系统管理员','2019-05-21 14:50:51',NULL,NULL,60),('60cf5000-cb37-4033-8a7f-23e917b03fc2','删除','Delete','/Admin/Menus/Delete','layui-icon layui-icon-delete','A6DC65C3-861B-421F-A192-8DBAA31351D5','删除',0,'系统管理员','2019-05-20 17:54:26','系统管理员','2019-05-21 14:46:08',40),('6bd5b10d-dc44-4718-85d0-3653e48e6d34','欢迎页','WelCome','/Admin/Home/WelCome','layui-icon layui-icon-face-smile-b','d1c96976-25a5-4a0a-87a4-0fcb6c5017ef',NULL,0,'系统管理员','2019-05-22 16:17:05',NULL,NULL,20),('81808F31-0805-44A7-9FB9-0C3280FB6472','查看','Index','/Admin/RapidDevelopment/Index','fa fa-eye','C7EC2A0B-BC81-40ED-9595-25840091F197','查看权限',0,'系统管理员','2019-05-13 13:51:51','系统管理员','2019-05-21 14:53:51',10),('823cd586-6995-474f-8123-7311e34fe7c6','管理','Manage',NULL,'layui-icon layui-icon-set-fill','3ca4b32b-30cc-4040-b6ac-34ac47059b78','编辑和删除权限',0,'系统管理员','2019-05-20 09:03:05',NULL,NULL,2),('87c35702-b37f-4e5d-b8c7-0432d5b33cb6','查看','Index','/Admin/Home/Index','fa fa-eye','d1c96976-25a5-4a0a-87a4-0fcb6c5017ef',NULL,0,'系统管理员','2019-05-22 16:16:48',NULL,NULL,10),('8ee15d16-fed1-4338-a4dc-bd83fedf4191','权限项删除','Delete','/Admin/Function/Delete','layui-icon layui-icon-delete','A6DC65C3-861B-421F-A192-8DBAA31351D5','权限项删除',0,'系统管理员','2019-05-21 14:51:52',NULL,NULL,80),('9bb79d19-1dc8-4030-8669-2d12c70ea23d','查看','Index',NULL,'layui-icon layui-icon-search','3ca4b32b-30cc-4040-b6ac-34ac47059b78','查看权限',0,'系统管理员','2019-05-20 09:03:05',NULL,NULL,1),('a19b4071-9513-4ec3-a584-6a59f6641b7f','测试','Test',NULL,'fas','8809e432-1fc9-43e5-b3da-8ce6b488e04f','测试',1,'系统管理员','2019-05-14 17:29:16','系统管理员','2019-05-15 15:07:21',30),('A1C11208-B87A-4BB9-BFF5-B0E580BA1A6D','查询列表','List','/Admin/UserInfo/List','layui-icon layui-icon-search','4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','查询列表',0,'系统管理员','2019-05-13 11:57:09','系统管理员','2019-05-21 14:44:20',20),('a50cd4e3-037d-46b7-b3aa-a8e7b7d1f88b','查看','Index',NULL,'ces','da8bb150-2a7a-49c9-aa34-2b27c621ae5a','查看权限',0,'系统管理员','2019-05-20 09:02:32','系统管理员','2019-05-20 10:58:32',NULL),('a5605de9-22a9-44c7-ace1-ffa8891179aa','查询列表','List','/WorkFlow/Home/List','layui-icon layui-icon-search','9dc4bce0-ca40-4cc2-ab61-927b7e247b8c','查询列表',0,'系统管理员','2019-05-24 15:49:24',NULL,NULL,20),('a8457fb7-3909-4680-a994-ac46bd0e4792','删除','Delete','/WorkFlow/Home/Delete','layui-icon layui-icon-delete','9dc4bce0-ca40-4cc2-ab61-927b7e247b8c','删除',0,'系统管理员','2019-05-24 15:49:24',NULL,NULL,40),('ad064726-9c82-463b-b415-fa45ac78a7a2','分配权限','SetPermission','/Admin/Role/SetPermission','layui-icon layui-icon-set-fill','2a164811-380c-4170-8f8a-783b921e1aab','设置权限',0,'系统管理员','2019-05-21 10:58:18','系统管理员','2019-05-21 14:53:13',50),('b916c45a-278d-4f9c-a5a5-6f986be9c6fa','删除','Delete','/Admin/Role/Delete','layui-icon layui-icon-delete','2a164811-380c-4170-8f8a-783b921e1aab','删除',0,'系统管理员','2019-05-21 10:56:46','系统管理员','2019-05-21 14:53:06',40),('C26CFB95-A74F-4793-A5CF-F7F75A195771','查看','Index','/Admin/UserInfo/Index','fa fa-eye','4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','查看权限',0,'系统管理员','2019-05-10 16:42:02','系统管理员','2019-05-21 14:44:12',10),('c5f38301-c712-4f73-80d1-f43d65508834','查看','Index','/WorkFlow/Home/Index','fa fa-eye','9dc4bce0-ca40-4cc2-ab61-927b7e247b8c','查看权限',0,'系统管理员','2019-05-24 15:49:24',NULL,NULL,10),('d379fca8-3440-423d-8a0a-4eb0639d25a3','权限项新增或编辑','Form','/Admin/Function/Form','layui-icon layui-icon-edit','A6DC65C3-861B-421F-A192-8DBAA31351D5','菜单的权限项新增或编辑',0,'系统管理员','2019-05-21 14:50:20',NULL,NULL,70),('D8E4E550-DF97-41C9-82A4-FF4ACDE5C8A2','新增或编辑','Form','/Admin/Menus/Form','layui-icon layui-icon-edit','A6DC65C3-861B-421F-A192-8DBAA31351D5','新增或编辑',0,'系统管理员','2019-05-13 13:51:06','系统管理员','2019-05-21 14:46:02',30),('E13DA120-41FE-4CAC-9F47-BEAC0629DEA2','查看','Index','/Admin/Menus/Index','fa fa-eye','A6DC65C3-861B-421F-A192-8DBAA31351D5','查看权限',0,'系统管理员','2019-05-13 13:50:23','系统管理员','2019-05-21 14:45:36',20),('E4757E56-BEA9-4998-A564-5F8B381D7BC8','查询列表','List','/Admin/RapidDevelopment/List','layui-icon layui-icon-search','C7EC2A0B-BC81-40ED-9595-25840091F197','查询列表',0,'系统管理员','2019-05-13 13:52:18','系统管理员','2019-05-21 14:53:57',20),('ea1dd383-80c6-4087-84af-5b6124cdbd3f','管理','Manage',NULL,'layui-icon layui-icon-set-fill','8809e432-1fc9-43e5-b3da-8ce6b488e04f','编辑和删除权限',0,'系统管理员','2019-05-14 16:47:28',NULL,NULL,2),('f721a1e5-a346-4d5a-91f3-5ca7ff07dfb2','查询列表','List','/Admin/Menus/List','layui-icon layui-icon-search','A6DC65C3-861B-421F-A192-8DBAA31351D5','查询列表',0,'系统管理员','2019-05-20 17:53:07','系统管理员','2019-05-21 14:45:42',20),('fede2115-0d6a-412c-a177-05ae3380e7f1','新增或编辑','Form','/Admin/UserInfo/Form','layui-icon layui-icon-edit','4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','新增或编辑',0,'系统管理员','2019-05-20 17:44:43','系统管理员','2019-05-21 14:44:27',30);

#
# Structure for table "sysmenus"
#

DROP TABLE IF EXISTS `sysmenus`;
CREATE TABLE `sysmenus` (
  `ObjectID` varchar(50) DEFAULT NULL,
  `MName` varchar(100) DEFAULT NULL,
  `MArea` varchar(100) DEFAULT NULL,
  `MController` varchar(100) DEFAULT NULL,
  `MIcon` varchar(100) DEFAULT NULL,
  `IsLast` int(11) DEFAULT NULL,
  `IsMenuShow` int(11) DEFAULT NULL,
  `Hierarchy` int(11) DEFAULT NULL,
  `Remark` varchar(500) DEFAULT NULL,
  `ParentID` varchar(50) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedTime` timestamp NULL DEFAULT NULL,
  `ModifiedBy` varchar(50) DEFAULT NULL,
  `ModifiedTime` timestamp NULL DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

#
# Data for table "sysmenus"
#

INSERT INTO `sysmenus` VALUES ('2a164811-380c-4170-8f8a-783b921e1aab','角色管理','Admin','Role','fa fa-circle-o',0,0,2,'角色管理','C7FD9389-2D50-47A7-AB59-510C7B49F570',0,'系统管理员','2019-05-14 15:48:18','系统管理员','2019-05-14 17:02:53',30),('2d37fe44-fa0b-49ec-b297-fd476405f020','测试',NULL,NULL,'fa fa-cog',1,0,1,NULL,'0',0,'系统管理员','2019-05-14 11:57:57','系统管理员','2019-05-22 16:12:04',990),('3ca4b32b-30cc-4040-b6ac-34ac47059b78','测试4',NULL,NULL,'1',0,0,2,NULL,'2d37fe44-fa0b-49ec-b297-fd476405f020',0,'系统管理员','2019-05-20 09:03:05','系统管理员','2019-05-20 09:03:19',40),('4e828c7f-9c2b-4a55-9eb5-ab461bd6a267','流程管理','WorkFlow',NULL,'fa fa-cubes',1,0,1,'流程管理','0',0,'系统管理员','2019-05-24 15:47:48','系统管理员','2019-05-24 15:50:14',30),('4E8926CF-3A4B-4E6A-B1AA-1A752B2CBC7F','用户管理','Admin','UserInfo','fa fa-circle-o',0,0,2,'用户管理','C7FD9389-2D50-47A7-AB59-510C7B49F570',0,'系统管理员','2019-05-09 17:30:41','系统管理员','2019-05-14 17:02:39',10),('4ed7719a-ea86-4b81-8929-8203978c18d9','测试2',NULL,'1','1',1,0,2,NULL,'2d37fe44-fa0b-49ec-b297-fd476405f020',0,'系统管理员','2019-05-14 17:26:56','系统管理员','2019-05-16 17:19:30',20),('8809e432-1fc9-43e5-b3da-8ce6b488e04f','ces',NULL,'1','1',0,0,3,NULL,'da6f1b62-186f-4828-bcf4-9c1dba16382a',0,'系统管理员','2019-05-14 16:47:28','系统管理员','2019-05-14 17:07:57',10),('9dc4bce0-ca40-4cc2-ab61-927b7e247b8c','流程模型','WorkFlow','Home','fa fa-circle-o',0,0,2,'流程模型','4e828c7f-9c2b-4a55-9eb5-ab461bd6a267',0,'系统管理员','2019-05-24 15:49:24','系统管理员','2019-05-24 15:50:50',10),('A6DC65C3-861B-421F-A192-8DBAA31351D5','菜单管理','Admin','Menus','fa fa-circle-o',0,0,2,'菜单管理','C7FD9389-2D50-47A7-AB59-510C7B49F570',0,'系统管理员','2019-05-09 17:34:02','系统管理员','2019-05-14 17:02:47',20),('C7EC2A0B-BC81-40ED-9595-25840091F197','代码生成','Admin','RapidDevelopment','fa fa-circle-o',0,0,2,'代码生成','C7FD9389-2D50-47A7-AB59-510C7B49F570',1,'系统管理员','2019-05-09 17:35:43','系统管理员','2019-05-27 11:06:11',40),('C7FD9389-2D50-47A7-AB59-510C7B49F570','系统设置',NULL,NULL,'fa fa-cog',1,0,1,'系统设置','0',0,'系统管理员','2019-05-09 15:50:00','系统管理员','2019-05-22 16:14:29',20),('d1c96976-25a5-4a0a-87a4-0fcb6c5017ef','后台主页123','Admin','Home','fa fa-cloud',1,1,1,'后台主页 不作为菜单显示','0',0,'系统管理员','2019-05-22 16:14:18',NULL,NULL,10),('da6f1b62-186f-4828-bcf4-9c1dba16382a','测试1',NULL,NULL,'a',1,0,2,NULL,'2d37fe44-fa0b-49ec-b297-fd476405f020',0,'系统管理员','2019-05-14 11:58:31','系统管理员','2019-05-14 17:08:01',10),('da8bb150-2a7a-49c9-aa34-2b27c621ae5a','测试2-1',NULL,NULL,'2',0,0,3,NULL,'4ed7719a-ea86-4b81-8929-8203978c18d9',0,'系统管理员','2019-05-16 17:20:16','系统管理员','2019-05-20 09:02:08',NULL),('f2e574f5-069f-474b-801c-e21ef0851460','测试3',NULL,NULL,'1',0,0,2,NULL,'2d37fe44-fa0b-49ec-b297-fd476405f020',0,'系统管理员','2019-05-14 17:30:43','系统管理员','2019-05-14 17:57:55',30);

#
# Structure for table "sysorganizationunit"
#

DROP TABLE IF EXISTS `sysorganizationunit`;
CREATE TABLE `sysorganizationunit` (
  `ObjectID` varchar(50) DEFAULT NULL,
  `OuParentID` varchar(50) DEFAULT NULL,
  `OuName` varchar(50) DEFAULT NULL,
  `OuLevel` int(11) DEFAULT NULL,
  `Remark` varchar(500) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedTime` timestamp NULL DEFAULT NULL,
  `ModifiedBy` varchar(50) DEFAULT NULL,
  `ModifiedTime` timestamp NULL DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

#
# Data for table "sysorganizationunit"
#


#
# Structure for table "sysrole"
#

DROP TABLE IF EXISTS `sysrole`;
CREATE TABLE `sysrole` (
  `ObjectID` varchar(50) DEFAULT NULL,
  `RName` varchar(50) DEFAULT NULL,
  `Remark` varchar(500) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedTime` timestamp NULL DEFAULT NULL,
  `ModifiedBy` varchar(50) DEFAULT NULL,
  `ModifiedTime` timestamp NULL DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

#
# Data for table "sysrole"
#

INSERT INTO `sysrole` VALUES ('7D6DF740-6213-4F99-A04F-FE489522B103','系统管理员','系统管理员，拥有所有权限',0,'系统管理员','2019-05-10 09:07:39','系统管理员','2019-05-10 09:07:49',1),('99BBFB26-5521-4BE5-99C0-0B8161335388','普通用户','普通用户，拥有基本权限',0,'系统管理员','2019-05-10 09:08:29',NULL,NULL,99);

#
# Structure for table "sysuserinfo"
#

DROP TABLE IF EXISTS `sysuserinfo`;
CREATE TABLE `sysuserinfo` (
  `ObjectID` varchar(50) DEFAULT NULL,
  `ULoginName` varchar(20) DEFAULT NULL,
  `ULoginPWD` varchar(50) DEFAULT NULL,
  `URealName` varchar(10) DEFAULT NULL,
  `UTelphone` varchar(20) DEFAULT NULL,
  `UMobile` varchar(11) DEFAULT NULL,
  `UEmail` varchar(50) DEFAULT NULL,
  `UQQ` varchar(20) DEFAULT NULL,
  `UGender` int(11) DEFAULT NULL,
  `UDepID` varchar(50) DEFAULT NULL,
  `Remark` varchar(500) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedTime` timestamp NULL DEFAULT NULL,
  `ModifiedBy` varchar(50) DEFAULT NULL,
  `ModifiedTime` timestamp NULL DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

#
# Data for table "sysuserinfo"
#

INSERT INTO `sysuserinfo` VALUES ('3FDC2296-8D1E-43CD-BBF3-4CA0FAF67005','admin','670b14728ad9902aecba32e22fa4f6bd','系统管理员',NULL,NULL,'1772829123@qq.com','1772829123',1,'1','系统管理员',0,'系统','2019-05-06 22:27:45','系统','2019-05-07 16:11:31',NULL),('D451D121-0AA5-4ECF-BD2A-2CDA443F795D','guest','670b14728ad9902aecba32e22fa4f6bd','测试用户',NULL,NULL,'1772829123@qq.com','1772829123',0,'1','测试用户',0,'系统','2019-05-06 22:22:40','系统','2019-05-07 16:12:14',NULL);

#
# Structure for table "tallydetailinfo"
#

DROP TABLE IF EXISTS `tallydetailinfo`;
CREATE TABLE `tallydetailinfo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `User` varchar(10) DEFAULT NULL,
  `TallyType` varchar(255) DEFAULT NULL,
  `ExpenseTime` datetime DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `Amount` decimal(18,2) DEFAULT NULL,
  `Remarks` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

#
# Data for table "tallydetailinfo"
#


#
# Structure for table "wfinstancetype"
#

DROP TABLE IF EXISTS `wfinstancetype`;
CREATE TABLE `wfinstancetype` (
  `ObjectID` varchar(50) DEFAULT NULL,
  `TypeName` char(10) DEFAULT NULL,
  `Remark` varchar(500) DEFAULT NULL,
  `ParentID` varchar(50) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedTime` timestamp NULL DEFAULT NULL,
  `ModifiedBy` varchar(50) DEFAULT NULL,
  `ModifiedTime` timestamp NULL DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

#
# Data for table "wfinstancetype"
#

