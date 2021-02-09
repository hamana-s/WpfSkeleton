. "./ps1/variable.ps1"

$ErrorActionPreference = "Stop"
dotnet build $solutionFolder
dotnet tool update -g dotnet-ef

$typeName = "System.Management.Automation.Host.ChoiceDescription"
$addMigration = New-Object $typeName("�}�C�O���[�V�����̒ǉ�(&1)", "�}�C�O���[�V���������w�肵�āA�V�K�}�C�O���[�V������ǉ����܂�")
$removeMigration = New-Object $typeName("�}�C�O���[�V�����̍폜(&2)", "���O�ɒǉ������}�C�O���[�V�������폜���܂�")
$updateMigration = New-Object $typeName("DB�̒�`���ŐV�ɍX�V(&3)", "DB�̒�`���ŐV�̏�ԂɍX�V���܂�")

$options = New-Object "System.Collections.ObjectModel.Collection``1[[$typeName]]"
$options.add($addMigration)
$options.add($removeMigration)
$options.add($updateMigration)

$result = $host.ui.PromptForChoice("����", "���s���鑀���I�����Ă�������", $options, 0)

switch ($result) {
    0 { powershell "../cmd/ps1/add-migration.ps1"; break }
    1 { powershell "../cmd/ps1/remove-migration.ps1"; break }
    2 { powershell "../cmd/ps1/update-database.ps1"; break }
}
