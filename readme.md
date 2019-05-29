# PickUpBug #  

動作保証環境  
OSWindows7(64bit)以上  
CPU: Intel core i3 以上  
GPU: DirectX10以上対応のグラフィックスカード  
メモリ: 4gb以上  

解像度につきましては 16:9 のみ想定しています。

UnityVersion : 2018.3.11f1  

## 製作動機  
  - PostProcessingStack v2の練習。
  - Visitorパターンのテスト。
  
### 操作方法
  - 移動:WASD  
  - ジャンプ:Space
  - メニュー:F1
  - 調べる(取得):左クリックorE
  - 持つ:右クリック
  
 ### 使用したAsset
  - モデル、オーディオ、テクスチャ、アニメーション全般。
  - PostProcessing Stack v2
  - FootstepsSystem
  - SpriteGlow [https://github.com/Elringus/SpriteGlow/]
  - VolumetricFog
  - フォントはフリーライセンスのものを使用。
  
 ### 感想、学んだ点
  - サークル内で見せる機会があったので一応ゲーム形式にしたが
  ステージ2で止まってるので未完成。
  - FPS視点のホラーにしようと思っていたが、ホラーな雰囲気を作るのは2Dより難しいと感じた。
  - PostProcessing stack v2 はレイヤー別に設定できるので分割してエフェクトを効果的につけれる。
  しかし、v1の時より手順が多い。
  - BrendTreeについて初めて詳しく調べた。アニメーション関連に対する苦手意識があるので克服したい。
  - 大量にランダムでオブジェクトを生成する場合Visitorパターンは細かく分けるべきかもしれない。
  
 ### 反省点
  - 設計をしないで作り始めたので、スパゲティコードになってしまった。
  - 可読性が低い。
  - 上手く最適化されておらず重い･･･。ここに関しては早急に知識をつけたい。
  - 追跡に関してNavメッシュを使用した方が圧倒的に短く済んでいた。(けど、より重くなってたかも？)
  - 作品としては全く面白く無いものになった。
  - 謎解き要素用にアイテムを持てるようにしたが、そもそも謎解きが実装されてない(2019/5/23)
 
 ### 次回目標
  - 要件定義、基本・詳細設計をしっかりする。
  - 配列、リストなどはLinqを使う。
  - ハイパーカジュアル系    
  - 同じゲームを一から綺麗に作り直すのも勉強になる気がする。
 
 #### GitHubを使用してみて(2019/5/23)
 恥ずかしながら今までGitHubを使ったことが無かったので、今回初めて使用しました。  
 使わなかった理由が「個人でしてる勉強だから」というものでしたが、チーム個人関係なく便利だなぁと感じました。
 データの共有、公開の為のツールという印象が強かったですが、いざ使ってみるとヴァージョン管理(Branch)
 の機能だけでも十分に使用する価値があると思いました。あとちょっと楽しいです。
 
 
 GitLFSなどいまいち理解しきれていないので、要勉強。
 良い機会ですのでここに自分へのメモ代わりに残しておこうと思います。
 
 README.mdファイル。マークダウン記法まとめ  
 [https://codechord.com/2012/01/readme-markdown/]  
 まずはGitの仕組みを理解することから(@Kyoyyyさん)  
 [https://qiita.com/kyoyyy/items/161b6905f45bee2efe21]  
 Git LFS でで大きめのバイナリファイルも Git で管理する (@msh5さん)  
 [https://qiita.com/msh5/items/582c086311d3630563bc]  
 manabuyasuda/GitHubの使い方  
 [https://gist.github.com/manabuyasuda/f449b313970c7a51b655]
 
 
