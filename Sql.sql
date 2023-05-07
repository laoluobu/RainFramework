DROP Database IF EXISTS `WMSDB`;
CREATE SCHEMA `WMSDB` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;



DROP TABLE IF EXISTS `user_info`;
CREATE TABLE `user_info`
(
    `id`          int                                                          NOT NULL AUTO_INCREMENT COMMENT '用户ID',
    `email`       varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL     DEFAULT NULL COMMENT '邮箱',
    `nickname`    varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '用户昵称',
    `is_disable`  tinyint(1)                                                   NOT NULL DEFAULT 0 COMMENT '是否禁用',
    `create_time` datetime                                                     NOT NULL COMMENT '创建时间',
    `update_time` datetime                                                     NULL     DEFAULT NULL COMMENT '更新时间',
    PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB
  AUTO_INCREMENT = 1024
  CHARACTER SET = utf8mb4
  COLLATE = utf8mb4_0900_ai_ci
  ROW_FORMAT = DYNAMIC;



