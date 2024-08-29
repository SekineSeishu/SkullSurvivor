# スカルサバイバー
Asset/Script/SKill<br>
それぞれのスキルの情報をScriptableObjectにしました<br>
<br>
Asset/Script/enemySpawner<br>
敵の生成位置を範囲内でランダムに決めて生成位置にコライダー(プレイヤーの周辺やマップ外の生成禁止エリア)があったら生成をキャンセルするようにした<br>
<br>
Asset/Script/SkillManager<br>
レベルアップした時にリストからランダムに選ばれたスキル情報をskillButtonに渡して生成するがその際に下記の条件のいずれかを満たしているものをリストから外して実行するようにした<br>
・スキルのレベルが最大<br>
・１つ目のボタンで選ばれているスキル<br>
skillButtonによってスキルがレベルアップした際にenumを使ってスキルの種類からそれぞれのskillManagerを呼び出してスキル情報を更新するようにした<br>
<br>
