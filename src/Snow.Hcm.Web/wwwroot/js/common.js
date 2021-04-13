/*********************************************
         * 根据身份证号获取性别
         *********************************************/
var getSexByIdCard = function (idCard) {
    var sexMap = { 0: "女", 1: "男" };
    if (idCard.length == 15) {
        return sexMap[idCard.substring(14, 15) % 2];
    } else if (idCard.length == 18) {
        return sexMap[idCard.substring(14, 17) % 2];
    } else {
        //不是15或者18,null
        return '';
    }
};
/*********************************************
 * 根据身份证号获取生日
 *********************************************/
var getBirthdayByIdCard = function (idCard) {
    var birthStr;
    if (15 == idCard.length) {
        birthStr = idCard.charAt(6) + idCard.charAt(7);
        if (parseInt(birthStr) < 10) {
            birthStr = '20' + birthStr;
        } else {
            birthStr = '19' + birthStr;
        }
        birthStr = birthStr + '-' + idCard.charAt(8) + idCard.charAt(9) + '-' + idCard.charAt(10) + idCard.charAt(11);
    } else if (18 == idCard.length) {
        birthStr = idCard.charAt(6) + idCard.charAt(7) + idCard.charAt(8) + idCard.charAt(9) + '-' + idCard.charAt(10) + idCard.charAt(11) + '-' + idCard.charAt(12) + idCard.charAt(13);
    }
    return birthStr;
};
/*********************************************
 * 根据身份证号获取出生地
 *********************************************/
var getAreaByIdCard = function (idCard) {
    return areaID[parseInt(idCard.substr(0, 2))];
};
/*********************************************
 * 根据身份证号获取年龄
 *********************************************/
var getAgeByIdCard = function (idCard) {
    var birthStr = getBirthdayByIdCard(idCard);
    var r = birthStr.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
    if (r == null) return '';
    var d = new Date(r[1], r[3] - 1, r[4]);
    if (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4]) {
        var Y = new Date().getFullYear();
        return (Y - r[1]);
    } else {
        return '';
    }
};
/*********************************************
 * 根据日期获取年龄
 * @param {Date} birthday 生日
 *********************************************/
var getAgeByBirthDay = function (birthday) {
    var returnAge,
        birthYear = birthday.getFullYear(),
        birthMonth = birthday.getMonth(),
        birthDay = birthday.getDate(),
        now = new Date(),
        nowYear = now.getFullYear(),
        nowMonth = now.getMonth() + 1,
        nowDay = now.getDate();
    if (nowYear == birthYear) {
        returnAge = 0;//同年 则为0周岁
    }
    else {
        var ageDiff = nowYear - birthYear; //年之差
        if (ageDiff > 0) {
            if (nowMonth == birthMonth) {
                var dayDiff = nowDay - birthDay;//日之差
                if (dayDiff < 0) {
                    returnAge = ageDiff - 1;
                } else {
                    returnAge = ageDiff;
                }
            } else {
                var monthDiff = nowMonth - birthMonth;//月之差
                if (monthDiff < 0) {
                    returnAge = ageDiff - 1;
                }
                else {
                    returnAge = ageDiff;
                }
            }
        } else {
            returnAge = -1;//返回-1 表示出生日期输入错误 晚于今天
        }
    }
    return returnAge;//返回周岁年龄
};