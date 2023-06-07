//using CodeFirstStoreFunctions;
//using RW.PMS.Common;
//using System;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;

//namespace RW.PMS.DAL
//{
//    public partial class RWPMS_DBDataContext : DbContext
//    {
//        /// <summary>
//        /// 连接字符串(解密)
//        /// </summary>
//        private static string _connectionString = string.Empty;
//        private static EDAEnums.DataBaseType _dbType = EDAEnums.DataBaseType.MsSql;

//        public virtual EDAEnums.DataBaseType DBType
//        {
//            get
//            {
//                return _dbType;
//            }
//        }

//        static RWPMS_DBDataContext()
//        {
//            //获取加密字符串
//            var decryptConnectionString = ConfigManager.GetConnectionString("RWPMS_DBDataContext");
//            if (string.IsNullOrEmpty(decryptConnectionString))
//            {
//                decryptConnectionString = ConfigManager.GetConnectionString("RWPMS_MySQLServer");
//                _dbType = EDAEnums.DataBaseType.MySql;
//            }
//            //解密
//            var decryptAndEncryptHelper = new DecryptAndEncryptHelper();
//            _connectionString = decryptAndEncryptHelper.Decrypto(decryptConnectionString);
//        }

//        public RWPMS_DBDataContext()
//            : base(_connectionString)
//        {

//        }

//        public virtual DbSet<assembly_errorInfo> assembly_errorInfo { get; set; }
//        public virtual DbSet<assembly_gb> assembly_gb { get; set; }
//        public virtual DbSet<assembly_gj> assembly_gj { get; set; }
//        public virtual DbSet<assembly_gw> assembly_gw { get; set; }
//        public virtual DbSet<assembly_gx> assembly_gx { get; set; }
//        public virtual DbSet<base_Device> base_Device { get; set; }
//        public virtual DbSet<base_gongbu> base_gongbu { get; set; }
//        public virtual DbSet<base_gongju> base_gongju { get; set; }
//        public virtual DbSet<base_gongwei> base_gongwei { get; set; }
//        public virtual DbSet<base_gongweiOPC> base_gongweiOPC { get; set; }
//        public virtual DbSet<base_gongweiRight> base_gongweiRight { get; set; }
//        public virtual DbSet<base_gongxu> base_gongxu { get; set; }
//        public virtual DbSet<base_gjwlOpcPoint> base_gjwlOpcPoint { get; set; }
//        public virtual DbSet<base_prodLjCheckTip> base_prodLjCheckTip { get; set; }
//        public virtual DbSet<base_product> base_product { get; set; }
//        public virtual DbSet<base_productioncalendar> base_productioncalendar { get; set; }
//        public virtual DbSet<base_productLingjian> base_productLingjian { get; set; }
//        public virtual DbSet<base_productModel> base_productModel { get; set; }
//        public virtual DbSet<base_program> base_program { get; set; }
//        public virtual DbSet<base_tempArea> base_tempArea { get; set; }
//        public virtual DbSet<base_Tools> base_Tools { get; set; }
//        public virtual DbSet<base_workmode> base_workmode { get; set; }
//        public virtual DbSet<base_testplat> base_testplat { get; set; }
//        public virtual DbSet<base_wuliao> base_wuliao { get; set; }
//        public virtual DbSet<device_checking> device_checking { get; set; }
//        public virtual DbSet<device_checkingDetails> device_checkingDetails { get; set; }
//        public virtual DbSet<device_upKeepPlan> device_upKeepPlan { get; set; }
//        public virtual DbSet<device_Remind> device_Remind { get; set; }
//        public virtual DbSet<device_run> device_run { get; set; }
//        public virtual DbSet<base_barcode> base_barcode { get; set; }
//        public virtual DbSet<follow_barcode_Log> follow_barcode_Log { get; set; }
//        public virtual DbSet<follow_check> follow_check { get; set; }
//        public virtual DbSet<follow_detail> follow_detail { get; set; }
//        public virtual DbSet<follow_faultRepair> follow_faultRepair { get; set; }
//        public virtual DbSet<follow_feedback> follow_feedback { get; set; }
//        public virtual DbSet<follow_gw> follow_gw { get; set; }
//        public virtual DbSet<follow_main> follow_main { get; set; }
//        public virtual DbSet<productInfo> productInfo { get; set; }
//        public virtual DbSet<follow_production> follow_production { get; set; }
//        public virtual DbSet<follow_WlLjBatching> follow_WlLjBatching { get; set; }
//        public virtual DbSet<gw_prod_def> gw_prod_def { get; set; }
//        public virtual DbSet<plan_prod> plan_prod { get; set; }
//        public virtual DbSet<product_test> product_test { get; set; }
//        public virtual DbSet<program_GbInfo> program_GbInfo { get; set; }
//        public virtual DbSet<program_GjInfo> program_GjInfo { get; set; }
//        public virtual DbSet<program_GjwlOPCInfo> program_GjwlOPCInfo { get; set; }
//        public virtual DbSet<program_GxInfo> program_GxInfo { get; set; }
//        public virtual DbSet<program_ValueInfo> program_ValueInfo { get; set; }
//        public virtual DbSet<sys_baseData> sys_baseData { get; set; }
//        public virtual DbSet<sys_baseDataType> sys_baseDataType { get; set; }
//        public virtual DbSet<sys_config> sys_config { get; set; }
//        public virtual DbSet<sys_department> sys_department { get; set; }
//        public virtual DbSet<sys_exeFileUpdate> sys_exeFileUpdate { get; set; }
//        public virtual DbSet<sys_loginInfo> sys_loginInfo { get; set; }
//        public virtual DbSet<sys_menu> sys_menu { get; set; }
//        public virtual DbSet<sys_role> sys_role { get; set; }
//        public virtual DbSet<sys_roleMenuDef> sys_roleMenuDef { get; set; }
//        public virtual DbSet<sys_User> sys_User { get; set; }
//        public virtual DbSet<test_ItemValueInfo> test_ItemValueInfo { get; set; }
//        public virtual DbSet<v_productModel> v_productModel { get; set; }
//        public virtual DbSet<sys_menu_auth> sys_menu_auth { get; set; }
//        public virtual DbSet<sys_auth> sys_auth { get; set; }
//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<assembly_errorInfo>()
//                .Property(e => e.errorDesp)
//                .IsUnicode(false);

//            modelBuilder.Entity<assembly_errorInfo>()
//                .Property(e => e.remark)
//                .IsUnicode(false);

//            modelBuilder.Entity<sys_auth>()
//               .HasMany(e => e.sys_menu_auth)
//               .WithRequired(e => e.sys_auth)
//               .HasForeignKey(e => e.authID)
//               .WillCascadeOnDelete(false);

//            modelBuilder.Entity<sys_menu>()
//                .HasMany(e => e.sys_menu_auth)
//                .WithRequired(e => e.sys_menu)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Conventions.Add(new FunctionsConvention("dbo", typeof(Functions)));

//            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//        }
//    }

//    internal static class Functions
//    {
//        [DbFunction("CodeFirstDatabaseSchema", "getBaseName")]
//        public static string getBaseName(int id)
//        {
//            throw new NotSupportedException();
//        }

//        [DbFunction("CodeFirstDatabaseSchema", "getBaseTypeName")]
//        public static string getBaseTypeName(string typecode)
//        {
//            throw new NotSupportedException();
//        }
//    }
//}
