   M S B A M L   `   `   `  ����  OChat.ClientUI1!    OChat.ClientUI1.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   -   5          � Title$  OChat - Join the fun��5   	    � SizeToContent$ WidthAndHeight=�6?    � WindowStartupLocation$ CenterScreen=�6^    � 
ResizeMode$ CanMinimize=�6�    +� FocusedElement 6�   ��  �� ElementName$ TxtUsername��.��5	      � $	��312��6   $	��151��6   .+�5
   
   �� $��	0,115,0,0q�6   
�������$��0,1,0,0q�6;   ._�5      � ���#F6F4F4$
��Left=�6(   $��35��6C   $��0q�6O   $	��Top=�6Z   $	��312��6r    � ColumnDefinitions 5      �� 5      $	��86* �6'   �� 5      $
��227* �6'   .+�5      "  FontAwesome.WPF.ImageAwesome  -   5        $��ImgBeginLogin��5   "    � ToolTip$ Connect to Server��6[   {�.     Icon$ SignIn=�6�   $��	191,5,5,5q�6�   	   
Foreground
	 ���F�
 J� Opacity$	
 0.6Q�6�    � Cursor$
 Hand��6�   $��1��6�   6�     5      -   5        $��ImgBugReport��5   2   $��0��6"   $	 Bug=�6i   $��5,5,55,5q�6t   
	 ���p�$ Report a Bug��6�   $
 Hand��6�    J� RenderTransformOrigin$ 
0.345,0.48&�6�     5      $��0��6"   $��	35,5,23,5q�62   $y�	Collapsed=�6E   
	 �����$8 2New Version of OChat available, click to download!��6v   $
 1Q�6�   $
 Hand��6�   $ 
0.345,0.48&�6�   $ Download=�5   J   5        5      -   5          Name$ SpinnerCog1��5   "      Spin . $ Spinner=�6C   $��
156,5,40,5q�6R   
	 �iii�   SpinDuration$ 2Q�6{   $y�	Collapsed=�6�   $��1��6�   5      5      �� 5   
   $��Host IPv4-Adress:��6   
���iii�$
��Left=�6A   $��5,13,0,0q�6\   $	��Top=�6n   $	��105��6�   �� 5   
   $��	Username:��6   
���iii�$
��Left=�69   $��5,75,0,0q�6T   $	��Top=�6f   $��92��6~   �� 5   
   $��Port:��6   
���iii�$
��Left=�65   $��5,44,0,0q�6P   $	��Top=�6b   $��92��6z   �� 5   
   -   5        $��BrdIpv4Adress��5      $��200,13,17,112q�6&   $��0,0,0,1q�6=   
�������._�5      �� -   5        $��TxtIpv4Adress��5      $��Center=�6M   
���iii�$��0q�6�   $
��Left=�6�    �� TextWrapping$
 Wrap=�6�   $��	127.0.0.1��6�   $	��Top=�6�   $��0q�6�   $��25��6�   $��94��6  5      �� 5   
   -   5        $��BrdPort��5      $��200,44,17,81q�6    $��0,0,0,1q�66   
�������._�5      �� -   5        $��TxtPort��5      $��Center=�6G   
���iii�$��0q�6~   $
��Left=�6�   $
 Wrap=�6�   $
��8931��6�   $	��Top=�6�   $��0q�6�   $��25��6�   $��94��6�   5       �� 5!   
   -	   5        $��BrdUsername��5!      $��200,75,17,50q�6$   $��0,0,0,1q�6:   
�������._�5"      �� -
   5         ��Name$ TxtUsername��5"       �� 	MaxLength$ 10��6M   |�. $��Center=�6m   
���iii�$��0q�6�   $
��Left=�6�   $
 Wrap=�6�   $	��Top=�6�   $��0q�6�   $��25��6
  $��94��6  5#      5$      5%      