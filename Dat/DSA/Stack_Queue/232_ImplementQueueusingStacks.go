package stackqueue

type MyQueue struct {
	a []int
	b []int
}

func Constructor() MyQueue {
	return MyQueue{
		a: []int{},
		b: []int{},
	}
}

func (this *MyQueue) Push(x int) {
	this.a = append(this.a, x)
}

func (this *MyQueue) Pop() int {
	this.move()
	n := len(this.b)
	val := this.b[n-1]
	this.b = this.b[:n-1]
	return val
}

func (this *MyQueue) Peek() int {
	this.move()
	return this.b[len(this.b)-1]
}

func (this *MyQueue) move() {
	if len(this.b) == 0 {
		for len(this.a) > 0 {
			n := len(this.a)
			val := this.a[n-1]
			this.a = this.a[:n-1]
			this.b = append(this.b, val)
		}
	}
}

func (this *MyQueue) Empty() bool {
	return len(this.a) == 0 && len(this.b) == 0
}
