# ChatAppServer .Net Core 6 <br/>
Bir Chat uygulamasıdır <br/>
Klasik kullancılar kayıt olup birbileri arasıda gruplar veya bire bir olarak konuşabilmektedir <br/>
Şuan Çalışır vaziyette fakat çok fazla eksik mevcut (herhangi bir validasyon bile bulunmamakta) <br/>
Bu projeyi yapma amacım WebSocket ve CQRS'i temel manada kavrayıp pratikte uygulamış olmak <br/>
Klasik Katmanlı mimaride CQRS Patter'ini uygulayanı görmedim ondan dosyaların konumlarında yanlışlar olabilir <br/>



-- Temel olarak kullandıgım teknolojiler/kütüphaneler --
Klasik Katmanlı Mimari , <br/>
CQRS Design Patterini elimden geldiğince kullanmaya çalıştım tek database'den çalıştım <br/>
Mediator <br/>
EFCore ve Migration <br/>
.Net Core İdentity ve JWT <br/>
WebSocket işlemleri için SignalR <br/>
