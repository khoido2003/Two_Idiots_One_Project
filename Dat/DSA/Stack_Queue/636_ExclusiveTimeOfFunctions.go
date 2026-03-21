package stackqueue

import (
	"strconv"
	"strings"
)

type Log struct {
	Id     int
	Action string
	Time   int
}

func formatLog(log string) Log {
	s := strings.Split(log, ":")
	id, _ := strconv.Atoi(s[0])
	time, _ := strconv.Atoi(s[2])

	return Log{
		Id:     id,
		Action: s[1],
		Time:   time,
	}
}

func exclusiveTime(n int, logs []string) []int {
	ans := make([]int, n)
	st := []Log{}

	for _, v := range logs {
		curr := formatLog(v)

		if curr.Action == "start" {
			if len(st) > 0 {
				prev := st[len(st)-1]
				ans[prev.Id] += curr.Time - prev.Time
				st[len(st)-1].Time = curr.Time
			}
			st = append(st, curr)
		} else {
			prev := st[len(st)-1]
			st = st[:len(st)-1]
			ans[prev.Id] += curr.Time - prev.Time + 1

			if len(st) > 0 {
				st[len(st)-1].Time = curr.Time + 1
			}
		}
	}

	return ans
}
