. "./ps1/set-location.ps1"
. "./ps1/variable.ps1"

Write-Output "�Ō�ɒǉ����ꂽ�}�C�O���[�V�������폜���܂��B��낵���ł����H"
$accept = Read-Host "���Ȃ����y����͌�A�G���^�[�L�[�������Ă�������"
if ($accept -ne "y") {
    exit
}

SetLocation
dotnet ef migrations remove -f --no-build --project:$project --startup-project:$startupProject --context:$context