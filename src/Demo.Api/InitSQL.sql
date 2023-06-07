use WMSDB;

use WMSDB;

INSERT INTO WMSDB.Roles (Id, RoleName, IsDisable, CreateTime, UpdateTime) VALUES (2, 'Administrator', 0, '2023-05-13 14:37:34', '2023-05-13 14:37:34');
INSERT INTO WMSDB.Roles (Id, RoleName, IsDisable, CreateTime, UpdateTime) VALUES (3, 'Customer', 0, '2023-05-13 14:37:34', '2023-05-13 14:37:34');

INSERT INTO WMSDB.UserAuths (Id, Username, Password, IpAddress, CreateTime, UpdateTime, LastLoginTime) VALUES (20, 'admin', 'e10adc3949ba59abbe56e057f20f883e', '127.0.0.1', '2023-05-13 14:37:34', '2023-05-13 14:37:34', '2023-05-13 14:37:34');
INSERT INTO WMSDB.RoleUserAuth (RolesId, UserAuthsId) VALUES (2, 20);
INSERT INTO WMSDB.UserInfos (Id, UserAuthId, Email, Nickname, IsDisable, CreateTime, UpdateTime) VALUES (1, 20, 'admin@email', '系统管理员', 0, '2023-05-13 14:37:34', '2023-05-13 14:37:34');

INSERT INTO WMSDB.SysMenus (Id, Path, Name, Component, Meta, ParentId, Hidden, OrderNum) VALUES (1, '/authManager/roleManager', 'roleManager', 'role/index.vue', '{"Icon": "el-icon-user"}', 2, 0, 2);
INSERT INTO WMSDB.SysMenus (Id, Path, Name, Component, Meta, ParentId, Hidden, OrderNum) VALUES (2, '/authManager', 'authManager', 'Layout', '{"icon": "el-icon-lock"}', null, 0, 1);
INSERT INTO WMSDB.SysMenus (Id, Path, Name, Component, Meta, ParentId, Hidden, OrderNum) VALUES (3, '/authManager/menusManager', 'menusManager', 'menu/index.vue', '{"icon": "el-icon-notebook-2"}', 2, 0, 1);
INSERT INTO WMSDB.SysMenus (Id, Path, Name, Component, Meta, ParentId, Hidden, OrderNum) VALUES (4, '/authManager/userManager', 'userManager', 'user/index.vue', '{"Icon": "el-icon-s-custom"}', 2, 0, 3);
INSERT INTO WMSDB.SysMenus (Id, Path, Name, Component, Meta, ParentId, Hidden, OrderNum) VALUES (5, '/userManager/profile', 'profile', 'profile/index.vue', '{"Icon": "el-icon-s-custom"}', 2, 1, 3);

INSERT INTO WMSDB.RoleSysMenu (RolesId, SysMenusId) VALUES (2, 1);
INSERT INTO WMSDB.RoleSysMenu (RolesId, SysMenusId) VALUES (2, 2);
INSERT INTO WMSDB.RoleSysMenu (RolesId, SysMenusId) VALUES (2, 3);
INSERT INTO WMSDB.RoleSysMenu (RolesId, SysMenusId) VALUES (2, 4);
INSERT INTO WMSDB.RoleSysMenu (RolesId, SysMenusId) VALUES (2, 5);
