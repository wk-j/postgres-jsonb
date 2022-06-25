CREATE TABLE jsonb_example (
  id bigserial,
  data JSONB
);

INSERT INTO
  jsonb_example (data)
VALUES
  ('{"a": {"b": ["foo", "hello"]}}'),
  ('{"a": {"b": ["chris", "render"]}}');