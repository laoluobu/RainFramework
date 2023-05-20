use WMSDB;
-- Add amin
insert into `Roles` values (2, 'Administrator', 0, '2023-05-13 14:37:34','2023-05-13 14:37:34');
insert into `UserAuths` values('20','admin','e10adc3949ba59abbe56e057f20f883e','127.0.0.1','2023-05-13 14:37:34','2023-05-13 14:37:34','2023-05-13 14:37:34');
insert into `RoleUserAuth` values(2,20);
insert into `UserInfos` values(1,20,'admin@email','系统管理员',0,'2023-05-13 14:37:34','2023-05-13 14:37:34');

insert into `SysMenus` values (2, '/authManger', 'Layout', '{\"title\":\"authManger\",\"icon\":\"el-icon-lock\"}',null,0,1,'authManger');
insert into `SysMenus` values (3, '/menusManger', 'menu/index.vue', '{\"title\":\"menusManger\",\"icon\":\"el-icon-notebook-2\"}',2,0,1,'menusManger');
insert into `RoleSysMenu` values(2,1);
insert into `RoleSysMenu` values(2,2);
insert into `RoleSysMenu` values(2,3);

