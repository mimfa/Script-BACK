   M S B A M L   `   `   `  ����  MiMFa Script-BACK    MiMFa.UIL.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$M  GMiMFa Script Based Application Custom-made Kit (Graphic User Interface)��5   	   $��447.029��6Y   $��750.248��6j    J� 	AllowDrop . $��Stretch=�6�   .��5      ]� $��Stretch=�6   $��Stretch=�6,   $��0,0,0,0q�6J    . .+�5	   
   ]� -   5         ]�Name$ dp��5	      $��Stretch=�6    $	��Top=�6>   $	��Top=�6S    . ��.  .+�5
      �� -   5         ��Name$ LV��5
      $��Stretch=�6#   $��Hidden=�6m   ���	#FFC7C7C7
���   �
�������$��Arial)�6�   ��. ��. $��1��6(  $
��Auto=�65   J� RenderTransformOrigin$ 0.5,0.5&�6e  $��Stretch=�6�  $��0,0,0,1q�6�  $	��282��6�  $��Right=�6�  $��0q�6�  $��Right=�6�  $	��Top=�6  $��50��6Q  ��6&  �� *Height+ �� ElementName$	 rtb��6Q  �� 5      -   5         ��Name$	 rtb��5      |�. $	��Top=�68   $��16(�6g   ��. " �� VerticalScrollBarVisibility$
 Auto=�6�   $��0q�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $��0��6  $��0��6  $��50��6%  $	��300��64  	 �� 
AcceptsTab	 . 
 J� IsManipulationEnabled
 .  � ForceCursor .  �� 	IsEnabled .  �� 	UndoLimit$
 1000��6�   � Cursor$  ��6�   �� IsDocumentEnabled . $	��Top=�6
  $��0,0,0,1q�6  $��Arial)�69  $��	Condensed&�6L   �� 
LineHeight$ 1��6d  ��6y  ��  �� Mode$ OneWay=�. �5      /� .T�5      J� .*�6    .*�5      �� 5      5      5      ]� 5      $��32��6   ��.  $	��Top=�6:   $��
0,0,-282,0q�6O   .+�5      ]� $��32��6   ��.  $��Center=�6>   $��Bottom=�6Y   $��0q�6q   $��Center=�6|   .+�5      �� -   5         ��Name$ button��5      $��Execute��6-   $��30��6?   $��0q�6K   ���	#FFFBFBFB���	#FFCFCFCF . $��Center=�6�   $��0q�6�   $��Center=�6�   $	��100��6  $��Center=�6  �� 5      -   5        $ button_Copy��5      $��Async Execute��62   $��30��6J   $��10,0,0,0q�6V   ���	#FFFBFBFB���	#FFCFCFCF . $��Center=�6�   $��0q�6�   $��Center=�6�   $	��100��6  $��Center=�6)  5      5      5      (  "System.Windows.Controls.WebBrowser  5   
   -   5          Name$ WB��5      $��Bottom=�6!   $��Stretch=�6:   $ 0.0,0.0&�6X   $��0q�6x    � UseLayoutRounding .   .  6�   5      5      