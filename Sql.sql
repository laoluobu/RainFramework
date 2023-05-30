
CREATE SCHEMA `WCSDB` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

use WCSDB;


CREATE TABLE `Roles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoleName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `IsDisable` tinyint(1) NOT NULL,
    `CreateTime` datetime(6) NOT NULL,
    `UpdateTime` datetime(6) NULL,
    CONSTRAINT `PK_Roles` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `SysMenus` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Path` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `Component` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `Meta` json NOT NULL,
    `ParentId` int NULL,
    `Hidden` tinyint(1) NOT NULL,
    `OrderNum` int NOT NULL,
    CONSTRAINT `PK_SysMenus` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_SysMenus_SysMenus_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `SysMenus` (`Id`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `UserAuths` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Username` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `Password` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `IpAddress` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `CreateTime` datetime(6) NOT NULL,
    `UpdateTime` datetime(6) NULL,
    `LastLoginTime` datetime(6) NULL,
    CONSTRAINT `PK_UserAuths` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `RoleSysMenu` (
    `RolesId` int NOT NULL,
    `SysMenusId` int NOT NULL,
    CONSTRAINT `PK_RoleSysMenu` PRIMARY KEY (`RolesId`, `SysMenusId`),
    CONSTRAINT `FK_RoleSysMenu_Roles_RolesId` FOREIGN KEY (`RolesId`) REFERENCES `Roles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_RoleSysMenu_SysMenus_SysMenusId` FOREIGN KEY (`SysMenusId`) REFERENCES `SysMenus` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `RoleUserAuth` (
    `RolesId` int NOT NULL,
    `UserAuthsId` int NOT NULL,
    CONSTRAINT `PK_RoleUserAuth` PRIMARY KEY (`RolesId`, `UserAuthsId`),
    CONSTRAINT `FK_RoleUserAuth_Roles_RolesId` FOREIGN KEY (`RolesId`) REFERENCES `Roles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_RoleUserAuth_UserAuths_UserAuthsId` FOREIGN KEY (`UserAuthsId`) REFERENCES `UserAuths` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `UserInfos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserAuthId` int NOT NULL,
    `Email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `Nickname` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `IsDisable` tinyint(1) NOT NULL,
    `CreateTime` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    `UpdateTime` datetime(6) NULL,
    CONSTRAINT `PK_UserInfos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_UserInfos_UserAuths_UserAuthId` FOREIGN KEY (`UserAuthId`) REFERENCES `UserAuths` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE UNIQUE INDEX `IX_Roles_RoleName` ON `Roles` (`RoleName`);


CREATE INDEX `IX_RoleSysMenu_SysMenusId` ON `RoleSysMenu` (`SysMenusId`);


CREATE INDEX `IX_RoleUserAuth_UserAuthsId` ON `RoleUserAuth` (`UserAuthsId`);


CREATE UNIQUE INDEX `IX_SysMenus_Name` ON `SysMenus` (`Name`);


CREATE INDEX `IX_SysMenus_ParentId` ON `SysMenus` (`ParentId`);


CREATE UNIQUE INDEX `IX_UserAuths_Username` ON `UserAuths` (`Username`);


CREATE UNIQUE INDEX `IX_UserInfos_UserAuthId` ON `UserInfos` (`UserAuthId`);


-- Add amin
insert into `Roles` values (2, 'Administrator', 0, '2023-05-13 14:37:34','2023-05-13 14:37:34');
insert into `Roles` values (3, 'Customer', 0, '2023-05-13 14:37:34','2023-05-13 14:37:34');

insert into `UserAuths` values('20','admin','e10adc3949ba59abbe56e057f20f883e','127.0.0.1','2023-05-13 14:37:34','2023-05-13 14:37:34','2023-05-13 14:37:34');
insert into `RoleUserAuth` values(2,20);
insert into `UserInfos` values(1,20,'admin@email','系统管理员',0,'2023-05-13 14:37:34','2023-05-13 14:37:34');



insert into `SysMenus` values (2, '/authManager', 'Layout','authManager', '{\"icon\":\"el-icon-lock\"}',null,0,1);
insert into `SysMenus` values (1, '/authManager/roleManager','roleManager', 'role/index.vue', '{\"icon\":\"el-icon-s-custom\"}',2,0,2);
insert into `SysMenus` values (3, '/authManager/menusManager','menusManager', 'menu/index.vue', '{\"icon\":\"el-icon-notebook-2\"}',2,0,1);
INSERT INTO `SysMenus` VALUES(4, '/authManager/userManager', 'userManager', 'user/index.vue', '{\"Icon\": \"el-icon-s-custom\"}', 2, 0, 3);
INSERT INTO `SysMenus` VALUES(5, '/userManager/profile', 'profile', 'profile/index.vue', '{\"Icon\": \"el-icon-s-custom\"}', 2, 1, 3);

insert into `RoleSysMenu` values(2,1);
insert into `RoleSysMenu` values(2,2);
insert into `RoleSysMenu` values(2,3);