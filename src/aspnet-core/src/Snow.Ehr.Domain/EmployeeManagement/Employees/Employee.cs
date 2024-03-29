﻿using System;
using System.Collections.Generic;
using Snow.Ehr.EmployeeManagement.EmergencyContacts;
using Snow.Ehr.EmployeeManagement.Salaries;
using Snow.Ehr.EmployeeManagement.WorkExperiences;
using Volo.Abp.Domain.Entities.Auditing;

namespace Snow.Ehr.EmployeeManagement.Employees
{
    /// <summary>
    /// 员工
    /// </summary>
    public class Employee:FullAuditedEntity<Guid>
    {
        public Employee()
        {
            EmergencyContacts = new List<EmergencyContact>();
            WorkExperiences = new List<WorkExperience>();
            Salaries = new List<Salary>();
        }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeNumber { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNumber { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCardNumber { get; set; }

        /// <summary>
        /// 开户行
        /// </summary>
        public string BankOfDeposit { get; set; }

        /// <summary>
        /// 婚姻状态
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        public PoliticalStatus PoliticalStatus { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 是否公历
        /// </summary>
        public bool IsGregorianCalendar { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// 转正日期
        /// </summary>
        public DateTime ConfirmationDate { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public Guid ProvinceId { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public Guid CityId { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public Guid DistrictId { get; set; }

        /// <summary>
        /// 村镇
        /// </summary>
        public Guid StreetId { get; set; }

        /// <summary>
        /// 属相
        /// </summary>
        public Zodiac Zodiac { get; set; }

        /// <summary>
        /// 星座
        /// </summary>
        public Constellation Constellation { get; set; }

        /// <summary>
        /// 血型
        /// </summary>
        public BloodType BloodType { get; set; }

        /// <summary>
        /// 在职状态
        /// </summary>
        public InServiceStatus InServiceStatus { get; set; }

        /// <summary>
        /// 违法或违纪行为
        /// </summary>
        public string ViolationOfLawOrDiscipline { get; set; }

        /// <summary>
        /// 重大病史
        /// </summary>
        public string MajorMedicalHistory { get; set; }

        /// <summary>
        /// 离职时间
        /// </summary>
        public DateTime? TimeOfDimission { get; set; }

        /// <summary>
        /// 头像Id
        /// </summary>
        public Guid? CoverImageMediaId { get; set; }

        /// <summary>
        /// 身份证照片-正面
        /// </summary>
        public Guid? IdCardPhotoPositive { get; set; }

        /// <summary>
        /// 身份证照片-背面
        /// </summary>
        public Guid? IdCardPhotoBack { get; set; }

        /// <summary>
        /// 紧急联系人
        /// </summary>
        public ICollection<EmergencyContact> EmergencyContacts { get; set; }

        /// <summary>
        /// 工作经历
        /// </summary>
        public ICollection<WorkExperience> WorkExperiences { get; set; }

        /// <summary>
        /// 工资
        /// </summary>
        public ICollection<Salary> Salaries { get; set; }
    }
}
