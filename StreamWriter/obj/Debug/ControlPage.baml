   M S B A M L   `   `   `  ����G  CStreamWriter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:StreamWriterStreamWriter  5      +clr-namespace:StreamWriterStreamWriter  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	          StreamWriter.ControlPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (iclr-namespace:StreamWriter     5      ,localclr-namespace:StreamWriter     5      .
viewModelsStreamWriter.ViewModels     5      9system&clr-namespace:System;assembly=mscorlib     5	        N� Title$  FiberBrigg - Control��5       
  WinAll#��[  5      .��5      � $��1,0,1,1q�6   ��5   
   �� 5       �� ImageSource$ images/Windmill.jpg��6    � ColumnDefinitions 5!   
   �� 5"      $��* �6   �� 5#      $
��2.8* �6    � RowDefinitions 5&   
   �� 5'      $
��Auto �6   �� 5(      $
��Auto �6   �� 5)      $
��Auto �6   �� 5*      $
��Auto �6   .+�50   
   �� $��0��6   $��0��6!     titleTextStyle#��[ 6.   $��2��6V   $��20q�6j   $"��FiberBragg Simulator    v1.2��6v   �� 51   
   -   5        $��1��51      $	��100��6!   $��30��6-   $��Right=�6U   $	��Top=�6q   $��10q�6�   .��6�   Internet Check6�   �� 54   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��1��6>   {�6K   �� *isUIEnabled+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�.+�55      ��   headerTextStyle#��[ 6   $��Center=�6=   $��Siemens Sans Black)�6X   .��6x   Frequency(1-1000):6�   �� 56      -   5        $��4��56      $��1��6&   $��Center=�63   $��2,0,2,0q�6N   $��80��57   }   ��60   �� *	frequency+$ PropertyChanged=�$ TwoWay=�.��6�   58      59      � 5?   
   $��2��6   $��1��6   $��
0,10,10,10q�6,   {�6@   �� *isUIEnabled+$ PropertyChanged=�$ TwoWay=� 5@      �� 5A      $
��Auto �6    �� 5B      $
��Auto �6    .+�5F      �� #��[ 6   $��Bottom=�6>   .��6Y   Sensor Setup(0-255):5H      A� 5J       A� Columns$ 8��6   $��1��6'   .+�5K      �� -   5        $��2,2,2,2q�5K   �   ��63   �� *tempNumPeak[0]+$ PropertyChanged=�$ TwoWay=�6�   �� 5L      -   5        $��2,2,2,2q�5L   �   ��63   �� *tempNumPeak[1]+$ PropertyChanged=�$ TwoWay=�6�   �� 5M      -   5        $��2,2,2,2q�5M   �   ��63   �� *tempNumPeak[2]+$ PropertyChanged=�$ TwoWay=�6�   �� 5N      -   5        $��2,2,2,2q�5N   �   ��63   �� *tempNumPeak[3]+$ PropertyChanged=�$ TwoWay=�6�   �� 5O      -   5        $��2,2,2,2q�5O   �   ��63   �� *tempNumPeak[4]+$ PropertyChanged=�$ TwoWay=�6�   �� 5P      -   5        $��2,2,2,2q�5P   �   ��63   �� *tempNumPeak[5]+$ PropertyChanged=�$ TwoWay=�6�   �� 5Q      -	   5        $��2,2,2,2q�5Q   �   ��63   �� *tempNumPeak[6]+$ PropertyChanged=�$ TwoWay=�6�   �� 5R      -
   5        $��2,2,2,2q�5R   �   ��63   �� *tempNumPeak[7]+$ PropertyChanged=�$ TwoWay=�6�   �� 5S      -   5        $��2,2,2,2q�5S   �   ��63   �� *tempNumPeak[8]+$ PropertyChanged=�$ TwoWay=�6�   �� 5T      -   5        $��2,2,2,2q�5T   �   ��63   �� *tempNumPeak[9]+$ PropertyChanged=�$ TwoWay=�6�   �� 5U      -   5        $��2,2,2,2q�5U   �   ��63   �� *tempNumPeak[10]+$ PropertyChanged=�$ TwoWay=�6�   �� 5V      -   5        $��2,2,2,2q�5V   �   ��63   �� *tempNumPeak[11]+$ PropertyChanged=�$ TwoWay=�6�   �� 5W      -   5        $��2,2,2,2q�5W   �   ��63   �� *tempNumPeak[12]+$ PropertyChanged=�$ TwoWay=�6�   �� 5X      -   5        $��2,2,2,2q�5X   �   ��63   �� *tempNumPeak[13]+$ PropertyChanged=�$ TwoWay=�6�   �� 5Y      -   5        $��2,2,2,2q�5Y   �   ��63   �� *tempNumPeak[14]+$ PropertyChanged=�$ TwoWay=�6�   �� 5Z      -   5        $��2,2,2,2q�5Z   �   ��63   �� *tempNumPeak[15]+$ PropertyChanged=�$ TwoWay=�6�   5[      5\      �� 5_   
   $ 
Horizontal=�6   $��Right=�6.   $��3��6J   $��1��6W   $��0,0,30,0q�6g   .+�5`      �� -   5         ��Name$ startButton��5`   Q   $��2,2,2,2q�61   $	��100��6B   $��Siemens Slab)�6f   .��6�   Start6�   �� 5a      -   5        $ 
stopButton��5a   b   $��2,2,2,2q�60   $	��100��6A   {�.  .��6v   Stop6|   5b      � 5f   
   	 � UseLayoutRounding	 . 
 J� SnapsToDevicePixels
 . $��1��6C   $
��Left=�6S   $��50��6n   $��0.4,37.4,0,-57q�6z   $��3��6�   $	��Top=�6�   $	��410��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   .+�5g      �� -   5         ��Name$ border��5g      
������� �� CornerRadius$ 3��6=   ���	#FFE7E4E4$��0,0,1.5,1.5q�6f   }�. ._�5h      �� 
������ 
���   �$��1.5,1.5,0,0q�6F   $ 2��6d    J� Effect 5j      3  -System.Windows.Media.Effects.DropShadowEffect  5k         ShadowDepth$ 0Q�6+      
BlurRadius$ 10Q�6;   5m      5n      �� 5q      $��Hidden=�6   $��3q�6M   .��5r      �� -   5         ��Name$ outputWindowLabel��5r      ��67   �� *outputMessage+$ PropertyChanged=�$ TwoWay=� 5s        5t      $ 0Q�6+   $ 0Q�6;      Color$ 	#00CA0808��6J      Opacity$ 0Q�6\   5v      5x      5y      �� 5�   
   $��2��6   $��0��6   $��2��6.   $��0,50.2,5.4,-15q�6B   $��2��6Z   .+�5�      �� 
�������$��0,0,6,0q�6/    �� Left$ 10��6A    � 	Resources 5�       �� 
TargetType �� Property �� Value �� 
TargetType d� 	IsChecked �� Path ��Name �� Triggers P� Property P� Value  �� 
TargetName��%{  '9�       7  �� 5�      " 9�6   .�5�      ��  � �� 5�      �� 5�   "   " 9�62   .R�5�   &   �  5�   *   �� 5�   .   $
��Auto �6<   �� 5�   .   $
��Auto �6<   .+�5�   *   �� $ 
Horizontal=�65   .+�5�   .   �� 8��  #��z��6]   6�   �� 5�   .   $��Center=�67    5�   2   �� 5�   6   $ 
errorState�6>   $ PropertyChanged=�6P   $ TwoWay=�6v   5�   /   5�   +   �� 5�   *   $
 body��5�   )   $��1��5�   )   #��z��66   5�   '    5�   &   P� 5�   *    �@9�
IsExpanded .  . �5�   .   �� $
  body��65    � y�$ 	Collapsed=�6]   5�   +   5�   #   5�      5�      5�      .@�5�      9� -   5        ! 9�Name$! errorModeExpander��5�      $��
Error mode��66   
�������{�6]   �� *isUIEnabled+$ PropertyChanged=�$ TwoWay=�.��5�      �� $ Vertical=�6!   $��
10,0,10,10q�69   .+�5�      �� .��6    Sensor number6/   �� 5�      -   5        ��5�   ;   �� *	eSensor+$ PropertyChanged=�$ TwoWay=��� 5�      $��Seconds��6    �� 5�      -   5        ��5�   ;   �� *eTime+$ PropertyChanged=�$ TwoWay=�5�      5�      5�      5�      5�      5�      