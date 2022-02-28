# WpfSkeleton

## 構成

### フォルダ構成

+---cmd             : DBマイグレーション用コマンドファイル
+---Models          : ドメインモデル(ビジネスロジック)のプロジェクト
|   +---DB          : DB関連ファイル
|   +---Migrations  : DBマイグレーション関連ファイル
|   \---Services    : サービス層
+---UnitTest        : 自動テスト
\---WpfSkeleton     : デスクトップアプリケーションプロジェクト
    +---Resources   : アイコンなど
    +---ViewModels  : 画面ごとのビューモデル
    \---Views       : 画面ごとのビュー

### プログラム構成

本アプリケーションは以下のMVVMアーキテクチャを採用しています。

User - View - View Model - (Model) - Service - Infrastructure
                    Test /

GUIとその他の処理(Model)を分離して自動テストが行えるようにしています
