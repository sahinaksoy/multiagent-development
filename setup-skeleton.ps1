# --- Flywheel Clean Architecture Setup Script ---

$slnName = "Flywheel"

Write-Host "🚀 Clean Architecture kurulumu başlıyor..." -ForegroundColor Cyan

# 1. Solution Dosyasını Oluştur
dotnet new sln -n $slnName
Write-Host "✅ Solution (.sln) oluşturuldu." -ForegroundColor Green

# 2. Domain Katmanı (Çekirdek - Bağımlılık Yok)
dotnet new classlib -n "$slnName.Domain" -o src/Domain
dotnet sln add src/Domain
# Gereksiz Class1.cs'yi sil
Remove-Item src/Domain/Class1.cs -ErrorAction SilentlyContinue
Write-Host "✅ Domain katmanı oluşturuldu." -ForegroundColor Green

# 3. Application Katmanı (Business Logic)
dotnet new classlib -n "$slnName.Application" -o src/Application
dotnet sln add src/Application
dotnet add src/Application reference src/Domain
# Paketler: MediatR (CQRS), FluentValidation, AutoMapper
dotnet add src/Application package MediatR
dotnet add src/Application package FluentValidation
dotnet add src/Application package AutoMapper
Remove-Item src/Application/Class1.cs -ErrorAction SilentlyContinue
Write-Host "✅ Application katmanı oluşturuldu ve paketleri yüklendi." -ForegroundColor Green

# 4. Infrastructure Katmanı (Database & External)
dotnet new classlib -n "$slnName.Infrastructure" -o src/Infrastructure
dotnet sln add src/Infrastructure
dotnet add src/Infrastructure reference src/Application
# Paketler: EF Core
dotnet add src/Infrastructure package Microsoft.EntityFrameworkCore
dotnet add src/Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
Remove-Item src/Infrastructure/Class1.cs -ErrorAction SilentlyContinue
Write-Host "✅ Infrastructure katmanı oluşturuldu." -ForegroundColor Green

# 5. WebApi Katmanı (Presentation)
dotnet new webapi -n "$slnName.WebApi" -o src/WebApi
dotnet sln add src/WebApi
dotnet add src/WebApi reference src/Infrastructure
dotnet add src/WebApi reference src/Application
# Paketler: MediatR Dependency Injection için
dotnet add src/WebApi package MediatR
Write-Host "✅ WebApi katmanı oluşturuldu." -ForegroundColor Green

Write-Host "🎉 İŞLEM TAMAMLANDI! Klasör yapısı 'src' altında hazır." -ForegroundColor Yellow