use WMSDB;

use WMSDB;
-- Add amin
insert into `Roles` values (2, 'Administrator', 0, '2023-05-13 14:37:34','2023-05-13 14:37:34');
insert into `Roles` values (3, 'Customer', 0, '2023-05-13 14:37:34','2023-05-13 14:37:34');

insert into `UserAuths` values('20','admin','e10adc3949ba59abbe56e057f20f883e','127.0.0.1','2023-05-13 14:37:34','2023-05-13 14:37:34','2023-05-13 14:37:34');
insert into `RoleUserAuth` values(2,20);
insert into `UserInfos` values(1,20,'admin@email','ϵͳ����Ա',0,'2023-05-13 14:37:34','2023-05-13 14:37:34');

insert into `SysMenus` values (2, '/authManager', 'Layout','authManager', '{\"icon\":\"el-icon-lock\"}',null,0,1);
insert into `SysMenus` values (1, '/authManager/roleManager','roleManager', 'role/index.vue', '{\"icon\":\"el-icon-s-custom\"}',2,0,2);
insert into `SysMenus` values (3, '/authManager/menusManager', 'menu/index.vue','menusManager', '{\"icon\":\"el-icon-notebook-2\"}',2,0,1);
INSERT INTO `SysMenus` VALUES(4, '/authManager/userManager', 'user/index.vue', 'userManager', '{\"Icon\": \"el-icon-s-custom\"}', 2, 0, 3);
INSERT INTO `SysMenus` VALUES(5, '/userManager/profile', 'profile/index.vue', 'profile', '{\"Icon\": \"el-icon-s-custom\"}', 2, 1, 3);

insert into `RoleSysMenu` values(2,1);
insert into `RoleSysMenu` values(2,2);
insert into `RoleSysMenu` values(2,3);
