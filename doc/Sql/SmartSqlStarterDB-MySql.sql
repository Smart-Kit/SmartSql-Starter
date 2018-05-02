SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for T_User
-- ----------------------------
DROP TABLE IF EXISTS `T_User`;
CREATE TABLE `T_User` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(100) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Status` smallint(6) NOT NULL,
  `LastLoginTime` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `CreationTime` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
