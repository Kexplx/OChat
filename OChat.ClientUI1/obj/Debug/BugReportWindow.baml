   M S B A M L   `   `   `  ����  OChat.ClientUI1%    OChat.ClientUI1.BugReportWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   -   5          � Title$  OChat - Join the Fun��5      
������� � 
ResizeMode$ CanMinimize=�5
       � SizeToContent$ WidthAndHeight=�5      
������� +� FocusedElement 5   4   ��  �� ElementName$ TxtBugReportMessage��.��5      � $	��312��6   $	��151��6   
�������.+�5   
   �� $��0,0,0,36q�6   
�������$��0,0,0,1q�6:   ._�5      �� -   5        $��TxtBugReportMessage��5      
�������
���iii� �� 
CaretBrush
 �iii�$��0q�6n   $��0q�6�   6�   5      �� 5   
    J� IsHitTestVisible .  $��15(�6-   $'��!Please Describe the Bug in detail��6;   $��Center=�6d   
�������$	��216��6�   $��48,47,48,83q�6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � y�	 �� Value$	 	Collapsed=�63   
 �� Triggers
 5      �� 5       �� Binding 6&   �� *Text+$ TxtBugReportMessage�� �� Value  6`   .a�5      ��  � y�$	 Visible=�6;   5      5      5      � 5   
   
�������$
��Left=�6'   $��35��6B   $��	0,115,0,0q�6N   $	��Top=�6a   $	��312��6y    � ColumnDefinitions 5      �� 5      $	��86* �6#   �� 5       $
��227* �6#   .+�5"      "  FontAwesome.WPF.ImageAwesome  -   5           Icon$
 Send=�5"      $��	191,5,5,5q�6*      
Foreground
 ���F� � Cursor$
 Hand��6r   $��1��6�    � ToolTip$ Report the Bug��6�   ��5#      �� 5$      "  6   .�5%      ��  � {�	 . 6E   �� 5&       �@J�Opacity$	 1Q�64   6@   
 5'      �� 5(       6*   �� *Text+$ TxtBugReportMessage��  6d   .a�5)   "   ��  � {�	 .  6N   �� 5*   "    �@J�Opacity$		 0.6Q�6<   6J   5+      5-      5/      �� 50      -   5        $��
LblVersion��50   $   $��0��6   $y�Visible=�66   $��	1,13,45,1q�6K   $��Center=�6^   $��10(�6{   
���iii�$��40��6�     51      -   5        $��SpinnerCog1��51      $y�	Collapsed=�61   $	 Cog=�6H   
 �iii�   Spin .    SpinDuration$ 2Q�6t   $��1��6�   $��
162,5,35,5q�6�   6�   52      53      54      