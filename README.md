## 基于ASP.Net Core开发一套通用后台框架
 

### 写在前面
这是本人在学习的过程中搭建学习的框架，如果对你有所帮助那再好不过。如果您有发现错误，请告知我，我会第一时间修改。 
知其然，知其所以然，并非重复的造轮子。因为这段时间我发现，自己闷很久写出来的代码，再去看看别人的，会有种恍然大悟的感觉。不是只会用，而不知道为什么要这样用。
真的，只看不敲，总是学不会。
> Demo地址：http://app.guoddy.com
> 源代码地址：https://github.com/jellydong/LJDAPP
> 数据并不会真实保存，设定的为测试模式，所以免登录。
 
#### 开发工具
>1.Visual Studio 2019
>2.SQL Server 2017 
>3.Power Design
### 总体效果
主页
![主页](/img/1.1.png)
菜单管理
![菜单管理](/img/1.2.png)
角色管理及权限配置
![菜单管理](/img/1.3.png)


### 权限设计&Why
![权限 ](/img/3.1.png)

>我这里主要涉及七个表，四个数据表，三个关联表。
>为什么这样设计，我觉得可能这是大多数系统的需求。
>1.用户和角色多对多，一个用户可以拥有多个角色，不然设计角色就没有了意义，实际可能一个人身兼数职。
>2.可以直接给用户授予或取消授予某个权限。这个可能会有人觉得没必要，所以如果不涉及这个，那就是五个表。但是我这里保留，因为很多情况下，这是很正常的需求。
>3.菜单可以无限级别，根据实际需求，修改系统配置参数。
#### 详细说明
`ObjectID`、`Remark`、`Status`、`CreatedBy`、`CreatedTime`、`ModifiedBy`、`ModifiedTime`、`Sort`是默认字段。
##### SysUserInfo用户表  
>* 如果用户数据量大的话，实际这个表只需要保留`ObjectID`、`ULoginName`、`ULoginPWD`就可以了，这样可以提高速度，没必要把所有信息都保存起来。
>* 用户和角色多对多  R_sysUserInfo_sysRole
>* 用户和权限项多对多(直接授权或禁止) R_UserPermissions

| Name  | 说明 | 类型 | 主键 |
| -------------| ------------- | ------------- | ------------- |  
|ObjectID 	|主键 	|nvarchar(50)|TRUE|
|ULoginName	 |	用户名	|	nvarchar(20)|	 	  |
|ULoginPWD	 |	密码	|	nvarchar(50)	| 	  |
|URealName	| 	真实姓名|		nvarchar(10) 	|	  | 
|UTelphone	 |	电话	|	nvarchar(20) 	|	  |
|UMobile	| 	手机号|		nvarchar(11) 	|	  |
|UEmail	 |	Email	|	nvarchar(50)	 |	  |
|UQQ	| 	QQ	|	nvarchar(20) |	  |
|UGender|	 	性别:0-女;1-男;2-保密| int	|		  |
|UDepID	 |	所属部门	|	nvarchar(50) |	  |
|Remark	 |	备注	|	nvarchar(500)	 	|  |
|Status	| 	状态:0-启用;1-禁用	| int	|		  |
|CreatedBy	| 	创建人	|	nvarchar(50) 	|  |
|CreatedTime|	 	创建时间	|	datetime	|		  |
|ModifiedBy	 |	修改人	|	nvarchar(50)	| 	  |
|ModifiedTime	| 	修改时间|		datetime		|	  |
|Sort	 |	排序值		 |	int|	  |
##### SysRole角色表
>* 对角色的分类，比如管理员、普通用户等。
>* 角色用户多对多   R_sysUserInfo_sysRole
>* 角色权限多对多   R_RolePermission

| Name  | 说明 | 类型 | 主键 |
| -------------| ------------- | ------------- | ------------- |   
| ObjectID| 主键| 	nvarchar(50)| TRUE| 
| RName| 角色名称| varchar(50)| | 
| Remark| 	备注| 	nvarchar(500)	| | 
| Status| 	状态:0-启用;1-禁用| int	| | 
| CreatedBy	| 	创建人| nvarchar(50) 	|| 
| CreatedTime| 创建时间	| 	datetime| |  
| ModifiedBy| 	修改人	| 	nvarchar(50)	| | 
| ModifiedTime	| 	修改时间|  datetime | | 
| Sort	| 	排序值	| 	int	| 	|  

##### SysMenus菜单表
>* 菜单表 是一开始设计好后，改动最多的一个表。后续在开发过程中增加了`IsLast`、`Hierarchy`;去除了`MAction`
>* IsLast用来标记是不是最后一级，如果是最后一级我们给自动增加增删改等默认方法。
>* Hierarchy用来标记层级，前面我们说可以做到无限极，但是通常情况下会是三级，所以这个需要根据实际设定系统参数，维护的时候检查限制即可。
>* IsMenuShow是否作为菜单显示，也就是左侧菜单递归的，因为有部分API不需要作为菜单显示，并且授权的方式也会不一样。
>* 菜单角色多对多  R_RolePermission
>* 菜单权限项一对多 

| Name  | 说明 | 类型 | 主键 |
| -------------| ------------- | ------------- | ------------- |    
| ObjectID| 主键| nvarchar(50)| TRUE| 
| MName	| 名称| nvarchar(100)| | 
| MUrl| URL| nvarchar(100)| | 
| MArea| 区域	| 	nvarchar(100)| | 
| MController| 控制器	| 	nvarchar(100)| | 
| MIcon	| 	图标	| 	nvarchar(100)| | 
| IsLast| 	是不是最后一级菜单:0-是;1-否	| 	int	| | 
| IsMenuShow| 	是不是作为菜单显示:0-是;1-否	| 	int	| | 
| Remark| 	备注	| 	nvarchar(500)| | 
| ParentID	| 	父ID	| 	nvarchar(50)| | 
| Status| 	状态:0-启用;1-禁用| int	| | 
| Hierarchy| 	层级	| 	int	| | 
| CreatedBy	| 	创建人	| 	nvarchar(50)| | 
| CreatedTime| 	创建时间| 		datetime| | 
| ModifiedBy| 	修改人	| 	nvarchar(50)| | 
| ModifiedTime| 	修改时间| 		datetime| | 
| Sort| 排序值	| 	int | | 

##### SysFunction <s>*菜单按钮表* </s> (菜单权限项表)

>* SysFunction一开始我是叫菜单按钮表的，我计划是查询、新增编辑删除、其他权限这样控制，但后来发现这样不好，所以全都分开，每个方法都要记录。当然为了方便，通用的方法，在增加菜单的时候会自动添加上。
>* 菜单权限项菜单是多对一关系 

| Name  | 说明 | 类型 | 主键 |
| -------------| ------------- | ------------- | ------------- |     
| ObjectID| 主键| nvarchar(50)| 	TRUE	|  
| FName| 	名称| nvarchar(50)| | 
| FFunction	| 方法| nvarchar(50)| | 
| FIcon| 图标| nvarchar(50) | | 
| ParentID| 	所属菜单| nvarchar(50)| | 
| Remark| 	备注| nvarchar(500)| | 
| Status	| 状态:0-启用;1-禁用| int	| | 
| CreatedBy	| 创建人| nvarchar(50)| | 
| CreatedTime	| 创建时间	| datetime| | 
| ModifiedBy| 修改人| 	nvarchar(50)| | 
| ModifiedTime	| 修改时间| datetime| | 
| Sort| 排序值	| int	| | 

##### R_sysUserInfo_sysRole用户和角色关联表，记录用户和角色的对应关系。
##### R_RolePermission 角色菜单权限项关联表。
> 比如一个角色有用某菜单下的查询和删除权限，那么这个表应该是具有两条记录的。
##### R_UserPermissions 用户菜单权限项关联表。
> `HavePermission`记录该用户是 是否有权限:0-无权限;1-有权限
> 后续处理的时候，要从获取的权限记录中排除直接无权限的记录，增加有权限的。

### 总结
其实网上很多关于权限的文章，之前自己再看的时候，总是觉得迷迷糊糊，所以最后打算自己动手做。到做完的时候，才有所理解。我也不知道我这里叙述的是不是不清楚或者设计的是否合理，如果您觉得有问题，请告知我，我会立即改正！
切勿眼高手低，动手敲，像Power Design我也是第一次用，也是第一次用MarkDown写博客。
> Demo地址：http://app.guoddy.com
> 源代码地址：https://github.com/jellydong/LJDAPP
> 数据并不会真实保存，设定的为测试模式，所以免登录。
