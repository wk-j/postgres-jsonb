# CMD

```bash
wk-send-command --command execute --user MyUser --password MyPassword --database MyDb \
    --file resource/create.sql

wk-send-command --command query --user MyUser --password MyPassword --database MyDb \
    --file resource/query.sql

wk-send-command --command query --user MyUser --password MyPassword --database MyDb \
    --file resource/query-json.sql

wk-send-command --command query --user MyUser --password MyPassword --database MyDb \
    --sql  "SELECT data #> '{a,b,1}' FROM jsonb_example"

wk-send-command --command query --user MyUser --password MyPassword --database MyDb \
    --sql "SELECT * FROM jsonb_example WHERE data['a']['b'][1] = '\"render\"'"

wk-send-command --command execute --user MyUser --password MyPassword --database MyDb \
    --sql "UPDATE jsonb_example SET data['a']['b'][0] = '\"bar\"';"
```