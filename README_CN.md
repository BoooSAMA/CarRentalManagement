[English](README.md)

# Car Rental Management（汽车租赁管理系统）

基于 **ASP.NET Core Blazor Interactive Server** 的汽车租赁管理 Web 应用。使用 C#、Entity Framework Core 和 SQL Server 构建。

---

## 技术栈

| 层级 | 技术 | 版本 |
|------|------|------|
| 框架 | ASP.NET Core（Blazor Interactive Server） | .NET 8.0 |
| 语言 | C# 12、HTML/Razor、CSS | — |
| ORM | Entity Framework Core | 8.0.11 |
| 数据库 | SQL Server（开发环境使用 LocalDB） | — |
| 身份认证 | ASP.NET Core Identity（Cookie + 角色） | 8.0.11 |
| UI | Blazor QuickGrid、Bootstrap 5 | — |

---

## 功能特性

### 后台管理（管理员角色）
- **品牌管理** — 汽车品牌的增删改查（如 BMW、Toyota）
- **车型管理** — 汽车型号的增删改查（如 i4、Prius）
- **颜色管理** — 车辆颜色的增删改查
- **车辆管理** — 车辆的增删改查（含车牌号、品牌/车型/颜色关联）

### 业务操作（所有已登录用户）
- **客户管理** — 客户信息的增删改查（驾照、地址、联系方式、邮箱）
- **租赁管理** — 租赁订单的增删改查（借出/归还日期、车辆、客户）

### 通用
- **用户注册与登录**（含邮箱确认）
- **基于角色的权限控制** — 管理员 vs 普通用户
- **个人资料管理** — 修改姓名、邮箱、电话、密码

---

## 系统架构

```
┌──────────────────────────────────────────────┐
│            Blazor Components（UI 层）         │
│   Razor 页面（内嵌 @code 代码块）             │
│   QuickGrid 数据表格、Bootstrap 样式          │
└──────────────────┬───────────────────────────┘
                   │
┌──────────────────▼───────────────────────────┐
│     Entity Framework Core DbContext（数据层）  │
│   CarRentalManagementContext                 │
└──────────────────┬───────────────────────────┘
                   │
┌──────────────────▼───────────────────────────┐
│           Domain Models（实体模型）            │
│   Make、Model、Colour、Vehicle、              │
│   Customer、Booking（+ BaseDomainModel）       │
└──────────────────┬───────────────────────────┘
                   │
┌──────────────────▼───────────────────────────┐
│          SQL Server（LocalDB）数据库            │
│   + ASP.NET Identity 身份认证表               │
└──────────────────────────────────────────────┘
```

---

## 数据模型

```
BaseDomainModel（抽象基类）
├── Id、DateCreated、DateUpdated、CreatedBy、UpdatedBy

Make（品牌）─────────────────┐
Model（型号）────────────────┼──→ Vehicle（车辆）
Colour（颜色）───────────────┘    ├── Id
                                  ├── LicensePlateNumber（车牌号）
                                  ├── MakeId、ModelId、ColourId

Customer（客户）                   Booking（租赁订单）
├── Id                              ├── Id
├── DrivingLicense（驾照号）        ├── DateOut（借出日期）
├── Address（地址）                 ├── DateIn（归还日期）
├── ContactNumber（联系电话）       ├── VehicleId、CustomerId
└── EmailAddress（邮箱）

CarRentalManagementUser : IdentityUser
├── FirstName
└── LastName
```

---

## 环境要求

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server LocalDB](https://learn.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb)（Visual Studio 自带）
- [Visual Studio 2022](https://visualstudio.microsoft.com/)（推荐）或其他代码编辑器

---

## 快速开始

### 1. 克隆仓库

```bash
git clone https://github.com/BoooSAMA/CarRentalManagement.git
cd CarRentalManagement
```

### 2. 还原依赖并更新数据库

```bash
cd CarRentalManagement
dotnet restore
dotnet ef database update
```

或在 Visual Studio 的包管理器控制台中执行：

```
Update-Database
```

### 3. 运行应用

```bash
dotnet run
```

或在 Visual Studio 中按 `F5`。

应用启动地址：
- HTTP: `http://localhost:5085`
- HTTPS: `https://localhost:7054`

---

## 默认管理员账号

首次运行时，数据库种子数据会自动创建以下账号：

| 角色 | 邮箱 | 密码 |
|------|------|------|
| 管理员 | `admin@localhost.com` | `P@ssword1` |

> ⚠️ **重要提醒**：生产环境中请立即修改管理员密码。密码及哈希值硬编码在源码中（`Configuration/Entities/UserSeed.cs` 和 `SeedUserRole` 迁移文件）。

---

## 项目结构

```
CarRentalManagement/
├── CarRentalManagement.slnx              # 解决方案文件
│
└── CarRentalManagement/                  # 主项目
    ├── Program.cs                        # 入口、依赖注入、中间件
    ├── appsettings.json                  # 连接字符串配置
    │
    ├── Domain/                           # 实体模型
    │   ├── BaseDomainModel.cs            # 抽象基类（审计字段）
    │   ├── Make.cs                       # 汽车品牌
    │   ├── Model.cs                      # 汽车型号
    │   ├── Colour.cs                     # 车辆颜色
    │   ├── Vehicle.cs                    # 车辆
    │   ├── Customer.cs                   # 客户
    │   └── Booking.cs                    # 租赁订单
    │
    ├── Data/                             # EF Core 数据层
    │   ├── CarRentalManagementContext.cs # 数据库上下文
    │   └── CarRentalManagementUser.cs    # 自定义用户实体
    │
    ├── Configuration/Entities/           # 种子数据
    │   ├── MakeSeed.cs                   # BMW、Toyota
    │   ├── ModelSeed.cs                  # i4、X5、Prius、C-HR
    │   ├── ColourSeed.cs                 # Black、Blue
    │   ├── UserSeed.cs                   # 默认管理员用户
    │   ├── UserRoleSeed.cs               # 角色分配
    │   └── RoleSeed.cs                   # 角色：管理员、用户
    │
    ├── Migrations/                       # EF Core 迁移（5 个）
    │
    ├── Components/                       # Blazor UI
    │   ├── Layout/
    │   │   ├── MainLayout.razor          # 侧边栏布局
    │   │   └── NavMenu.razor             # 权限感知导航菜单
    │   ├── Pages/
    │   │   ├── Home.razor                # 首页
    │   │   ├── AdminPages/               # 管理端 CRUD（品牌/型号/颜色/车辆）
    │   │   ├── CustomerPages/            # 客户 CRUD
    │   │   └── BookingPages/             # 租赁订单 CRUD
    │   └── Account/                      # Identity 页面（登录、注册等）
    │
    └── wwwroot/                          # 静态资源（CSS、Bootstrap、图标）
```

---

## 页面路由

| 路由 | 页面 | 访问权限 |
|------|------|----------|
| `/` | 首页 | 公开 |
| `/makes` | 品牌列表 | 管理员 |
| `/models` | 型号列表 | 管理员 |
| `/colours` | 颜色列表 | 管理员 |
| `/vehicles` | 车辆列表 | 管理员 |
| `/customers` | 客户列表 | 已登录用户 |
| `/bookings` | 租赁列表 | 已登录用户 |
| `/Account/Login` | 登录 | 公开 |
| `/Account/Register` | 注册 | 公开 |
| `/Account/Manage` | 个人资料 | 已登录用户 |

---

## 数据库迁移历史

| 迁移 | 日期 | 变更内容 |
|------|------|----------|
| `Initial` | 2025-11-30 | 基础表结构 + Identity 身份表 |
| `SeedData` | 2025-11-30 | 种子颜色数据 |
| `AddIdentity` | 2025-11-30 | 种子品牌 + 型号，重命名表 |
| `SeedUserRole` | 2025-11-30 | 种子角色、用户、角色分配 |

---

## 安全注意事项

- 🔴 **管理员凭据硬编码**在 `UserSeed.cs` 和 `SeedUserRole` 迁移中。生产环境使用前务必修改。
- 🟡 **未配置邮件发送器**（`IdentityNoOpEmailSender`）—— 邮箱确认和密码重置邮件实际不会发送。
- 🟡 **仅配置 LocalDB** —— 无生产环境数据库连接字符串。
- 🟡 **缺少外键导航属性** —— 车辆和租赁订单的外键缺少显式实体关系定义。
- 🟢 **防伪令牌已启用** —— CSRF 保护已激活。
- 🟢 **HSTS 已配置** —— 非开发环境强制 HTTPS。

---

## 许可证

本项目采用 MIT 许可证。详见 [LICENSE](LICENSE)。
