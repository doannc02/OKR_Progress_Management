using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_NetCore.Models.Entitiess
{
    public partial class OKEAContext : DbContext
    {
        public OKEAContext()
        {
        }

        public OKEAContext(DbContextOptions<OKEAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountGrantRole> AccountGrantRoles { get; set; } = null!;
        public virtual DbSet<AccountToken> AccountTokens { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<CfrsuggestAnswer> CfrsuggestAnswers { get; set; } = null!;
        public virtual DbSet<CfrsuggestComment> CfrsuggestComments { get; set; } = null!;
        public virtual DbSet<CfrsuggestQuestion> CfrsuggestQuestions { get; set; } = null!;
        public virtual DbSet<CheckInHistory> CheckInHistories { get; set; } = null!;
        public virtual DbSet<CheckInKeyResult> CheckInKeyResults { get; set; } = null!;
        public virtual DbSet<CheckInObjective> CheckInObjectives { get; set; } = null!;
        public virtual DbSet<CheckInOkr> CheckInOkrs { get; set; } = null!;
        public virtual DbSet<CheckInSchedule> CheckInSchedules { get; set; } = null!;
        public virtual DbSet<ConfigType> ConfigTypes { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DepartmentType> DepartmentTypes { get; set; } = null!;
        public virtual DbSet<DepartmentUser> DepartmentUsers { get; set; } = null!;
        public virtual DbSet<ElearningAnswer> ElearningAnswers { get; set; } = null!;
        public virtual DbSet<ElearningLession> ElearningLessions { get; set; } = null!;
        public virtual DbSet<ElearningQuestion> ElearningQuestions { get; set; } = null!;
        public virtual DbSet<ElearningQuestionType> ElearningQuestionTypes { get; set; } = null!;
        public virtual DbSet<ElearningSetting> ElearningSettings { get; set; } = null!;
        public virtual DbSet<ElearningSubject> ElearningSubjects { get; set; } = null!;
        public virtual DbSet<ElearningTestingDetail> ElearningTestingDetails { get; set; } = null!;
        public virtual DbSet<ElearningTestingResult> ElearningTestingResults { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<FeedbackImage> FeedbackImages { get; set; } = null!;
        public virtual DbSet<KeyResult> KeyResults { get; set; } = null!;
        public virtual DbSet<KeyResultAction> KeyResultActions { get; set; } = null!;
        public virtual DbSet<ManagerSchedule> ManagerSchedules { get; set; } = null!;
        public virtual DbSet<NewRanking> NewRankings { get; set; } = null!;
        public virtual DbSet<Objective> Objectives { get; set; } = null!;
        public virtual DbSet<Okr> Okrs { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Quarter> Quarters { get; set; } = null!;
        public virtual DbSet<QuestionType> QuestionTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleOfUser> RoleOfUsers { get; set; } = null!;
        public virtual DbSet<ScriptManagement> ScriptManagements { get; set; } = null!;
        public virtual DbSet<StarFund> StarFunds { get; set; } = null!;
        public virtual DbSet<StarTransaction> StarTransactions { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<SystemConfiguration> SystemConfigurations { get; set; } = null!;
        public virtual DbSet<TradingHistory> TradingHistories { get; set; } = null!;
        public virtual DbSet<Tutorial> Tutorials { get; set; } = null!;
        public virtual DbSet<TutorialType> TutorialTypes { get; set; } = null!;
        public virtual DbSet<UpgradeVersion> UpgradeVersions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NFH2VNK\\SQLEXPRESS;Initial Catalog=OKEA;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountGrantRole>(entity =>
            {
                entity.ToTable("AccountGrantRole");
            });

            modelBuilder.Entity<AccountToken>(entity =>
            {
                entity.ToTable("AccountToken");

                entity.HasIndex(e => e.Token, "UQ__AccountT__1EB4F817033F96F5")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpiredAt).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Admins__A9D10534AD4FA72B")
                    .IsUnique();

                entity.HasIndex(e => e.LoginName, "UQ__Admins__DB8464FF309FB91E")
                    .IsUnique();

                entity.Property(e => e.AdminRole).HasDefaultValueSql("((1))");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.LoginName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CfrsuggestAnswer>(entity =>
            {
                entity.ToTable("CFRSuggestAnswer");

                entity.Property(e => e.Answer).HasMaxLength(250);

                entity.Property(e => e.Question).HasMaxLength(250);
            });

            modelBuilder.Entity<CfrsuggestComment>(entity =>
            {
                entity.ToTable("CFRSuggestComment");

                entity.Property(e => e.Comment).HasMaxLength(500);

                entity.Property(e => e.Star).HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<CfrsuggestQuestion>(entity =>
            {
                entity.ToTable("CFRSuggestQuestion");

                entity.Property(e => e.Question).HasMaxLength(250);

                entity.Property(e => e.QuestionType).HasMaxLength(250);
            });

            modelBuilder.Entity<CheckInHistory>(entity =>
            {
                entity.ToTable("CheckInHistory");

                entity.Property(e => e.Cfrcomment)
                    .HasMaxLength(500)
                    .HasColumnName("CFRComment");

                entity.Property(e => e.CfrcommentManager)
                    .HasMaxLength(500)
                    .HasColumnName("CFRCommentManager");

                entity.Property(e => e.ConfidenceLevel).HasDefaultValueSql("((100))");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ManagerEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerFullName).HasMaxLength(200);

                entity.Property(e => e.MarkPoint).HasDefaultValueSql("((100))");

                entity.Property(e => e.MemberEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MemberFullname).HasMaxLength(200);

                entity.Property(e => e.MemberRole).HasDefaultValueSql("((1))");

                entity.Property(e => e.NextTime).HasColumnType("datetime");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CheckInKeyResult>(entity =>
            {
                entity.ToTable("CheckInKeyResult");

                entity.Property(e => e.Answer).HasMaxLength(2000);

                entity.Property(e => e.CfrcommentKr)
                    .HasMaxLength(1000)
                    .HasColumnName("CFRCommentKR");

                entity.Property(e => e.CfrsuggestAnswerId).HasColumnName("CFRSuggestAnswerId");

                entity.Property(e => e.CfrsuggestQuestionId).HasColumnName("CFRSuggestQuestionId");

                entity.Property(e => e.CommentKr)
                    .HasMaxLength(2000)
                    .HasColumnName("CommentKR");

                entity.Property(e => e.ConfidenceLevel).HasDefaultValueSql("((100))");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.KeyResultName).HasMaxLength(200);

                entity.Property(e => e.ManagerEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerFullName).HasMaxLength(200);

                entity.Property(e => e.MarkPoint).HasDefaultValueSql("((100))");

                entity.Property(e => e.MemberEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MemberFullname).HasMaxLength(200);

                entity.Property(e => e.MemberRole).HasDefaultValueSql("((1))");

                entity.Property(e => e.NextTime).HasColumnType("datetime");

                entity.Property(e => e.ObjectiveName).HasMaxLength(200);

                entity.Property(e => e.QuarterName).HasMaxLength(50);

                entity.Property(e => e.Question).HasMaxLength(2000);

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CheckInObjective>(entity =>
            {
                entity.ToTable("CheckInObjective");

                entity.Property(e => e.Answer).HasMaxLength(2000);

                entity.Property(e => e.CfrcommentObj)
                    .HasMaxLength(1000)
                    .HasColumnName("CFRCommentObj");

                entity.Property(e => e.CfrsuggestAnswerId).HasColumnName("CFRSuggestAnswerId");

                entity.Property(e => e.CfrsuggestQuestionId).HasColumnName("CFRSuggestQuestionId");

                entity.Property(e => e.CheckInOkrid).HasColumnName("CheckInOKRId");

                entity.Property(e => e.CommentObj).HasMaxLength(1000);

                entity.Property(e => e.ConfidenceLevel).HasDefaultValueSql("((100))");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ManagerEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerFullName).HasMaxLength(200);

                entity.Property(e => e.MarkPoint).HasDefaultValueSql("((100))");

                entity.Property(e => e.MemberEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MemberFullname).HasMaxLength(200);

                entity.Property(e => e.MemberRole).HasDefaultValueSql("((1))");

                entity.Property(e => e.NextTime).HasColumnType("datetime");

                entity.Property(e => e.ObjectiveName).HasMaxLength(200);

                entity.Property(e => e.Okrid).HasColumnName("OKRId");

                entity.Property(e => e.Okrname)
                    .HasMaxLength(200)
                    .HasColumnName("OKRName");

                entity.Property(e => e.Okrpercent).HasColumnName("OKRPercent");

                entity.Property(e => e.Okrstatus).HasColumnName("OKRStatus");

                entity.Property(e => e.Question).HasMaxLength(2000);

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CheckInOkr>(entity =>
            {
                entity.ToTable("CheckInOKR");

                entity.Property(e => e.Answer).HasMaxLength(2000);

                entity.Property(e => e.CfrcommentOkr)
                    .HasMaxLength(1000)
                    .HasColumnName("CFRCommentOKR");

                entity.Property(e => e.CfrsuggestAnswerId).HasColumnName("CFRSuggestAnswerId");

                entity.Property(e => e.CfrsuggestQuestionId).HasColumnName("CFRSuggestQuestionId");

                entity.Property(e => e.CommentOkr)
                    .HasMaxLength(1000)
                    .HasColumnName("CommentOKR");

                entity.Property(e => e.ConfidenceLevel).HasDefaultValueSql("((100))");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ManagerEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerFullName).HasMaxLength(200);

                entity.Property(e => e.MarkPoint).HasDefaultValueSql("((100))");

                entity.Property(e => e.MemberEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MemberFullname).HasMaxLength(200);

                entity.Property(e => e.MemberRole).HasDefaultValueSql("((1))");

                entity.Property(e => e.NextTime).HasColumnType("datetime");

                entity.Property(e => e.Okrid).HasColumnName("OKRId");

                entity.Property(e => e.Okrname)
                    .HasMaxLength(200)
                    .HasColumnName("OKRName");

                entity.Property(e => e.Okrpercent).HasColumnName("OKRPercent");

                entity.Property(e => e.Okrstatus).HasColumnName("OKRStatus");

                entity.Property(e => e.Question).HasMaxLength(2000);

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CheckInSchedule>(entity =>
            {
                entity.ToTable("CheckInSchedule");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastTimeCheckIn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ManagerEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerFullName).HasMaxLength(200);

                entity.Property(e => e.MemberEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MemberFullName).HasMaxLength(200);

                entity.Property(e => e.NextTimeCheckIn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ConfigType>(entity =>
            {
                entity.ToTable("ConfigType");

                entity.HasIndex(e => e.Description, "UQ__ConfigTy__4EBBBAC9C167DCBB")
                    .IsUnique();

                entity.HasIndex(e => e.Type, "UQ__ConfigTy__F9B8A48BF45E06EF")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentStructure)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentType).HasMaxLength(250);

                entity.Property(e => e.ManagerEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerFullName).HasMaxLength(200);

                entity.Property(e => e.ManagerLoginName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentName).HasMaxLength(250);
            });

            modelBuilder.Entity<DepartmentType>(entity =>
            {
                entity.ToTable("DepartmentType");

                entity.HasIndex(e => e.Type, "UQ__Departme__F9B8A48BBF4C8694")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ManagerType).HasMaxLength(250);

                entity.Property(e => e.Type).HasMaxLength(250);
            });

            modelBuilder.Entity<DepartmentUser>(entity =>
            {
                entity.ToTable("DepartmentUser");

                entity.Property(e => e.DepartmentName).HasMaxLength(250);

                entity.Property(e => e.DepartmentStructure)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserEmail).HasMaxLength(200);

                entity.Property(e => e.UserFullName).HasMaxLength(200);

                entity.Property(e => e.UserRoleName).HasMaxLength(250);
            });

            modelBuilder.Entity<ElearningAnswer>(entity =>
            {
                entity.ToTable("ElearningAnswer");

                entity.Property(e => e.Answer).HasMaxLength(200);

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Question).HasMaxLength(200);
            });

            modelBuilder.Entity<ElearningLession>(entity =>
            {
                entity.ToTable("ElearningLession");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FeatureImage)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LessionContent).HasColumnType("ntext");

                entity.Property(e => e.LessionTitle).HasMaxLength(200);

                entity.Property(e => e.SubjectName).HasMaxLength(200);
            });

            modelBuilder.Entity<ElearningQuestion>(entity =>
            {
                entity.ToTable("ElearningQuestion");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Question).HasMaxLength(200);

                entity.Property(e => e.QuestionType).HasMaxLength(200);

                entity.Property(e => e.SubjectName).HasMaxLength(200);
            });

            modelBuilder.Entity<ElearningQuestionType>(entity =>
            {
                entity.ToTable("ElearningQuestionType");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.QuestionType).HasMaxLength(200);
            });

            modelBuilder.Entity<ElearningSetting>(entity =>
            {
                entity.ToTable("ElearningSetting");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ElearningSubject>(entity =>
            {
                entity.ToTable("ElearningSubject");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SubjectName).HasMaxLength(200);
            });

            modelBuilder.Entity<ElearningTestingDetail>(entity =>
            {
                entity.ToTable("ElearningTestingDetail");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ElearningTestingResult>(entity =>
            {
                entity.ToTable("ElearningTestingResult");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TestingTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserFullName).HasMaxLength(250);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Content).HasMaxLength(1000);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FeedbackNote).HasMaxLength(250);

                entity.Property(e => e.Fullname).HasMaxLength(250);

                entity.Property(e => e.Rate).HasDefaultValueSql("((1))");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<FeedbackImage>(entity =>
            {
                entity.ToTable("FeedbackImage");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KeyResult>(entity =>
            {
                entity.ToTable("KeyResult");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.KeyResultName).HasMaxLength(200);

                entity.Property(e => e.ObjectiveName).HasMaxLength(200);

                entity.Property(e => e.ObjectiveType).HasDefaultValueSql("((1))");

                entity.Property(e => e.QuarterData).HasMaxLength(50);

                entity.Property(e => e.QuarterName).HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserFullname).HasMaxLength(200);
            });

            modelBuilder.Entity<KeyResultAction>(entity =>
            {
                entity.ToTable("KeyResultAction");

                entity.Property(e => e.ActionName).HasMaxLength(200);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.KeyResultName).HasMaxLength(200);

                entity.Property(e => e.ObjectiveType).HasDefaultValueSql("((1))");

                entity.Property(e => e.QuarterData).HasMaxLength(50);

                entity.Property(e => e.QuarterName).HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserFullname).HasMaxLength(200);
            });

            modelBuilder.Entity<ManagerSchedule>(entity =>
            {
                entity.ToTable("ManagerSchedule");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<NewRanking>(entity =>
            {
                entity.ToTable("NewRanking");

                entity.HasIndex(e => e.Email, "UQ__Rankings__A9D105342BEF130B")
                    .IsUnique();

                entity.Property(e => e.Avatar)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.DepartmentName).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.Role).HasMaxLength(200);
            });

            modelBuilder.Entity<Objective>(entity =>
            {
                entity.ToTable("Objective");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ObjectiveName).HasMaxLength(200);

                entity.Property(e => e.ObjectiveType).HasDefaultValueSql("((1))");

                entity.Property(e => e.OkrName).HasMaxLength(200);

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserFullname).HasMaxLength(200);
            });

            modelBuilder.Entity<Okr>(entity =>
            {
                entity.ToTable("Okr");

                entity.Property(e => e.DepartmentName).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.OkrType).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserFullname).HasMaxLength(200);

                entity.Property(e => e.UserRole).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Method)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Quarter>(entity =>
            {
                entity.ToTable("Quarter");

                entity.HasIndex(e => e.Name, "UQ__Quarter__737584F6989057F8")
                    .IsUnique();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.ToTable("QuestionType");

                entity.HasIndex(e => e.Define, "UQ__Question__464CE15827597330")
                    .IsUnique();

                entity.Property(e => e.Define).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Controller)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<RoleOfUser>(entity =>
            {
                entity.ToTable("RoleOfUser");

                entity.HasIndex(e => e.Role, "UQ__RoleOfUs__DA15413E92C656A7")
                    .IsUnique();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Role).HasMaxLength(200);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ScriptManagement>(entity =>
            {
                entity.ToTable("ScriptManagement");

                entity.HasIndex(e => e.SqlScriptFile, "UQ__ScriptMa__7D71C72946169085")
                    .IsUnique();

                entity.Property(e => e.ExecuteTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SqlScriptFile)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StarFund>(entity =>
            {
                entity.ToTable("StarFund");

                entity.HasIndex(e => e.YearFund, "UQ__StarFund__FE0346B73482B663")
                    .IsUnique();

                entity.Property(e => e.CreateDtime)
                    .HasColumnType("datetime")
                    .HasColumnName("CreateDTime");

                entity.Property(e => e.UpdateLuby).HasColumnName("UpdateLUBy");

                entity.Property(e => e.UpdateLudtime)
                    .HasColumnType("datetime")
                    .HasColumnName("UpdateLUDTime");
            });

            modelBuilder.Entity<StarTransaction>(entity =>
            {
                entity.ToTable("StarTransaction");

                entity.Property(e => e.AdminFullname).HasMaxLength(200);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ReceiverEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverFullname).HasMaxLength(200);

                entity.Property(e => e.ReceiverRole).HasMaxLength(200);

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserFullname).HasMaxLength(200);

                entity.Property(e => e.UserRole).HasMaxLength(200);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsAlwaysAvaiable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductDescription).HasMaxLength(500);

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.ProductPriority).HasDefaultValueSql("((10))");

                entity.Property(e => e.ProductQuantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SystemConfiguration>(entity =>
            {
                entity.ToTable("SystemConfiguration");

                entity.HasIndex(e => e.ConfigKey, "UQ__SystemCo__4A3067842C3501FC")
                    .IsUnique();

                entity.Property(e => e.ConfigKey)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigValue)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<TradingHistory>(entity =>
            {
                entity.ToTable("TradingHistory");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.TradingTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserFullname).HasMaxLength(200);

                entity.Property(e => e.UserRole).HasMaxLength(200);
            });

            modelBuilder.Entity<Tutorial>(entity =>
            {
                entity.Property(e => e.AuthorEmail).HasMaxLength(200);

                entity.Property(e => e.AuthorFullName).HasMaxLength(200);

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FeatureImage).HasMaxLength(300);

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.TutorialType).HasMaxLength(200);
            });

            modelBuilder.Entity<TutorialType>(entity =>
            {
                entity.HasIndex(e => e.TutorialType1, "UQ__Tutorial__247E784AE64E1E88")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TutorialType1)
                    .HasMaxLength(200)
                    .HasColumnName("TutorialType");
            });

            modelBuilder.Entity<UpgradeVersion>(entity =>
            {
                entity.ToTable("UpgradeVersion");

                entity.HasIndex(e => e.Version, "UQ__UpgradeV__0F54013450181695")
                    .IsUnique();

                entity.Property(e => e.BugFixedNote).HasMaxLength(500);

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpgradeNote).HasMaxLength(500);

                entity.Property(e => e.UpgradedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "UQ__User__A9D105341E071870")
                    .IsUnique();

                entity.Property(e => e.ActivationCode)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.DepartmentName).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role).HasMaxLength(200);

                entity.Property(e => e.UserRole).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.Property(e => e.DepartmentType).HasMaxLength(250);

                entity.Property(e => e.Role).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
