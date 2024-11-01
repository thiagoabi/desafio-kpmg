using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Identity_InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var newIdAdmin = Guid.NewGuid();
            var newIdUser = Guid.NewGuid();
            
            var newIdRoleAdmin = Guid.NewGuid();
            var newIdRoleUser = Guid.NewGuid();

            var sql = $@"
                INSERT INTO AspNetUsers
                    (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
                    VALUES(N'{newIdAdmin}', N'admin@kpmgcm.com', N'ADMIN@KPMGCM.COM', N'admin@kpmgcm.com', N'ADMIN@KPMGCM.COM', 1, N'AQAAAAIAAYagAAAAEIGkCOtBIzzipxE/5lZaDEmTGLcpa6bVVaZjzKG8AhPhoFUPhugzz/2286q+c6FQ5A==', N'HHLAKROUUHMCHH3VM2JJPALWNML7ESA3', N'53be0292-8256-4b32-9534-9b5c88af5702', NULL, 0, 0, NULL, 0, 0);
                GO
                INSERT INTO AspNetUsers
                    (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
                    VALUES(N'{newIdUser}', N'user@kpmgcm.com', N'USER@KPMGCM.COM', N'user@kpmgcm.com', N'USER@KPMGCM.COM', 1, N'AQAAAAIAAYagAAAAENb/FZ0fVbDn5mglFegR6Bf9iYbuTLw+QIAwdskh+spluiuwPanJ1FCJ+tm4y27Nmw==', N'MIXUPUSGGBXD5QCKNDXQONL6U2VAWRBR', N'472eaf05-c261-4ec6-83ad-abb8cc6f6c4d', NULL, 0, 0, NULL, 1, 0);
                GO
                INSERT INTO AspNetRoles (Id, ConcurrencyStamp, Name, NormalizedName) VALUES(N'{newIdRoleAdmin}', NULL, N'Admin', N'ADMIN');
                GO
                INSERT INTO AspNetRoles (Id, ConcurrencyStamp, Name, NormalizedName) VALUES(N'{newIdRoleUser}', NULL, N'User', N'USER');
                GO
                INSERT INTO AspNetUserRoles (UserName, RoleId) VALUES(N'{newIdAdmin}', N'{newIdRoleAdmin}');
                GO
                INSERT INTO AspNetUserRoles (UserName, RoleId) VALUES(N'{newIdUser}', N'{newIdRoleUser}');";

            migrationBuilder.Sql(sql);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
