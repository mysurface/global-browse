#!/bin/bash


## config start here ##
gview=myview_name
subfolder_list=~/script/my_sources_path.txt

export GTAGSROOT=/vobs
export GTAGSDBPATH=~/GtagsDB/MY_PROJECT_TAGS

## config end here ##

inview=`cleartool lsview -cview 2> /dev/null`

if [[ -z $inview ]]
## if currently not in the view, setview accordingly
then
    cleartool setview -exec $0 $gview
    exit 0
else
    myview=`echo $inview | awk '{print $(NF-1)}'`
fi

if [[ $myview != $gview ]]
then
    echo "ERR: wrong view, program terminate"
    exit 1
fi

## START the real work here ##

# generate source_list
if [ ! -e $GTAGSDBPATH ];
then
    mkdir -p $GTAGSDBPATH
fi

cd $GTAGSROOT

date
echo "Generate source_list ..."

rm -f $GTAGSDBPATH/source_list
rm -f $GTAGSDBPATH/*error.log

while read sub
do
    #find $sub -type f \( -name '*.cpp' -o -name '*.h' -o -name '*.hpp' -o -name '*.cc' -o -name '*.c' \) -print >> $GTAGSDBPATH/source_list 2>>$GTAGSDBPATH/source_error.log
	find $sub \( -type f -or -type l \) -and \( -name '*.cpp' -o -name '*.h' -o -name '*.hpp' -o -name '*.cc' -o -name '*.c' \) -print >> $GTAGSDBPATH/source_list 2>>$GTAGSDBPATH/source_error.log
done < $subfolder_list

date
echo "Perform Gtags ..."
gtags -f $GTAGSDBPATH/source_list $GTAGSDBPATH 2>>$GTAGSDBPATH/gtags_error.log

date

echo "Generate symbol_list ..."
global -c  > $GTAGSDBPATH/symbol_list

date
echo "Done."
