   M S B A M L   `   `   `  ????K  GDivisionPractice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DivisionPractice.ViewsDivisionPractice.Views  5   	   %    DivisionPractice.Views.MainView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:DivisionPractice.Views     5   	     ? Title$  MainView??5   	   $	??300??6    ? SizeToContent$ Height=?5	   	   
???????.??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6    ? ColumnDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      .+?5   
   ?? $??0??6   $??0??5      $??割られる数 :??5       ?? TextAlignment$ Right=?5      $??Center=?5      ?? 5   
   $??0??6   $??1??5      $??2q?5      ??5      ?? *Lhs+ ?? UpdateSourceTrigger$ PropertyChanged=??? 5!   
   $??1??6   $??0??5"      $??	割る数??5#      $ Right=?5$      $??Center=?5%      ?? 5&   
   $??1??6   $??1??5'      $??2q?5(      ??5)      ?? *Rhs+$ PropertyChanged=??? 5+   
   $??2??6   $??0??5,      $??2??5-      $??割り算する??5.      $??2q?5/      ??50      ?? *
DivCommand+?? 51   
   $??3??6   $??0??52      $??結果??53      $ Right=?54      $??Center=?55      ?? 56   
   $??3??6   $??1??57       ?? 
IsReadOnly . $??2q?59      ??5:      ?? *Result+ ?? Mode$ OneWay=?5;      5<      