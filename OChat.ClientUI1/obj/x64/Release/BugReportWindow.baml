   M S B A M L   `   `   `  ����   OChat.ClientUI1%    OChat.ClientUI1.BugReportWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  -     � Title$  OChat - Join the Fun��
������� � 
ResizeMode$ CanMinimize=� � SizeToContent$ WidthAndHeight=�
������� +� FocusedElement ��  �� ElementName$ TxtBugReportMessage��.��� $	��312��$	��151��
�������.+��� $��0,0,0,35q�
�������$��0,0,0,1q�._��� -   $��TxtBugReportMessage��
�������
���iii� �� 
CaretBrush
 �iii�$��0q���  J� IsHitTestVisible .  $��15(�$'��!Please Describe the Bug in detail��$��Center=�
�������$	��216��$��48,47,48,83q�����  �� 
TargetType" ��.���  �� Property � y�	 �� Value$	 	Collapsed=�
 �� Triggers
 ��  �� Binding �� *Text+$ TxtBugReportMessage�� �� Value  .a���  � y�$	 Visible=�� ���#F6F4F4$
��Left=�$��36��$��	0,116,0,0q�$	��Top=�$	��312�� � ColumnDefinitions �� $	��86* ��� $
��227* �.+�"  FontAwesome.WPF.ImageAwesome  -      Icon$
 Send=�$��	191,5,5,5q�   
Foreground
 ���F� � Cursor$
 Hand��$��1�� � ToolTip$ Report the Bug������ "  .���  � {�	 . ��  �@J�Opacity$	 1Q�
 ��  �� *Text+$ TxtBugReportMessage��  .a���  � {�	 .  ��  �@J�Opacity$		 0.6Q�  -   $��SpinnerCog1��$y�	Collapsed=�$ Spinner=�
 �iii�   Spin .    SpinDuration$ 2Q�$��1��$��
162,5,35,5q�