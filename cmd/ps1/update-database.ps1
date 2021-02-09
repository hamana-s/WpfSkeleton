. "./ps1/set-location.ps1"
. "./ps1/variable.ps1"

$connectionString = Read-Host "�X�V�Ώ�DB�̐ڑ����������͂��Ă�������"
if([string]::IsNullOrWhiteSpace($connectionString)) {
    exit
}

SetLocation
dotnet ef database update --no-build --verbose --project:$project --startup-project:$startupProject --context:$context --connection:$connectionString
